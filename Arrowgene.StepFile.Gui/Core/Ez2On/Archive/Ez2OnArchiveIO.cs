using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Arrowgene.Services.Buffers;
using Arrowgene.Services.Extra;
using Arrowgene.Services.Logging;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Archive
{
    public class Ez2OnArchiveIO
    {
        public static string OsToHdrPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                path = path.Replace('/', '\\');
                if (path[0] == '\\')
                {
                    path = path.Substring(1);
                }

                if (path[path.Length - 1] != '\\')
                {
                    path = path + '\\';
                }
            }

            return path;
        }

        public static string HdrToOsPath(string path)
        {
            string result = "";
            if (!string.IsNullOrEmpty(path))
            {
                path = path.Replace('\\', '/');
                string[] parts = path.Split('/');

                foreach (string part in parts)
                {
                    result = Path.Combine(result, part);
                }
            }

            return result;
        }

        private const int IndexBlockSize = 268;
        private const int MaxNameLength = 260;
        private const int TroHeaderLength = 20;
        private const int DatHeaderLength = 40;
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        // 949 | ks_c_5601-1987 | Korean
        public static readonly Encoding KoreanEncoding = CodePagesEncodingProvider.Instance.GetEncoding(949);
        private static readonly IBufferProvider BufferProvider = new StreamBuffer();

        private Logger _logger;

        private static readonly List<string> IgnoreFiles = new List<string>()
        {
            ".ds_store",
        };

        public Ez2OnArchiveIO()
        {
            _logger = LogProvider<Logger>.GetLogger(this);
        }

        public event EventHandler<Ez2OnArchiveIOEventArgs> ProgressChanged;

        public Ez2OnArchive Read(string sourcePath)
        {
            byte[] hdrFile = Utils.ReadFile(sourcePath);
            IBuffer buffer = BufferProvider.Provide(hdrFile);
            buffer.SetPositionStart();
            Ez2OnArchive archive = new Ez2OnArchive();
            string first = buffer.ReadCString();
            if (first == Ez2OnArchive.Hdr)
            {
                archive.Format = Ez2OnArchive.Hdr;
                archive.Created = null;
                archive.ArchiveType = Ez2OnArchiveType.Tro;
            }
            else if (DateTime.TryParseExact(first,
                Ez2OnArchiveIO.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var created))
            {
                archive.Created = created;
                archive.Format = buffer.ReadCString();
                archive.ArchiveType = Ez2OnArchiveType.Dat;
            }
            else
            {
                _logger.Write(LogLevel.Error, "Can not read header, this is not a hdr file or the file is broken. ({0})", sourcePath);
                return null;
            }
            archive.CryptoType = buffer.ReadInt32();
            archive.ContentOffset = buffer.ReadInt32();
            archive.FolderCount = buffer.ReadInt32();
            archive.IndexOffset = buffer.ReadInt32();
            int folderIndexStart = archive.IndexOffset;
            int totalFiles = 0;
            int currentFile = 0;
            for (int i = 0; i < archive.FolderCount; i++)
            {
                buffer.Position = folderIndexStart + i * Ez2OnArchiveIO.IndexBlockSize;
                Ez2OnArchiveIndex folderIndex = ReadIndex(buffer);
                totalFiles += folderIndex.Length;
                Ez2OnArchiveFolder folder = new Ez2OnArchiveFolder();
                folder.SetFullPath(folderIndex.Name);
                buffer.Position = folderIndex.Offset;
                for (int j = 0; j < folderIndex.Length; j++)
                {
                    Ez2OnArchiveIndex fileIndex = ReadIndex(buffer);
                    int offset = fileIndex.Offset;
                    int lenght = fileIndex.Length;
                    string fileExtension = "";
                    if (Path.HasExtension(fileIndex.Name))
                    {
                        fileExtension = Path.GetExtension(fileIndex.Name);
                    }
                    Ez2OnArchiveFile file = new Ez2OnArchiveFile();
                    file.Extension = fileExtension;
                    file.Name = fileIndex.Name;
                    file.DirectoryPath = folderIndex.Name;
                    file.FullPath = folderIndex.Name + fileIndex.Name;
                    file.Data = buffer.GetBytes(offset, lenght);
                    file.Offset = offset;
                    file.Length = lenght;
                    file.Encrypted = archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE;
                    archive.Files.Add(file);
                    folder.Files.Add(file);
                    OnProgressChanged("READ", folderIndex.Name, totalFiles, currentFile++);
                }
                archive.AddFolder(folder);
            }
            return archive;
        }

        public void Write(Ez2OnArchive archive, string destinationPath)
        {
            Dictionary<string, List<Ez2OnArchiveFile>> folderDictionary = new Dictionary<string, List<Ez2OnArchiveFile>>();
            List<string> orderedKeys = new List<string>();
            foreach (Ez2OnArchiveFile file in archive.Files)
            {
                string[] folderNameParts = file.DirectoryPath.Split('\\');
                string folderName = "";
                for (int i = 0; i < folderNameParts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(folderNameParts[i]))
                    {
                        folderName += folderNameParts[i] + '\\';
                        if (!folderDictionary.ContainsKey(folderName))
                        {
                            folderDictionary.Add(folderName, new List<Ez2OnArchiveFile>());
                            orderedKeys.Add(folderName);
                        }
                    }
                }
                string directoryPath = file.DirectoryPath;
                if (!string.IsNullOrEmpty(directoryPath) && !directoryPath.EndsWith("\\"))
                {
                    directoryPath += "\\";
                }
                if (folderDictionary.ContainsKey(directoryPath))
                {
                    folderDictionary[directoryPath].Add(file);
                }
                else
                {
                    folderDictionary.Add(directoryPath, new List<Ez2OnArchiveFile>() { file });
                    orderedKeys.Add(directoryPath);
                }
            }
            orderedKeys.Sort((s1, s2) => string.Compare(s1, s2, StringComparison.InvariantCultureIgnoreCase));
            IBuffer buffer = BufferProvider.Provide();
            int totalFiles = archive.Files.Count;
            int currentFile = 0;
            int folderIndexStart = TroHeaderLength;
            if (archive.ArchiveType == Ez2OnArchiveType.Dat)
            {
                folderIndexStart = DatHeaderLength;
            }
            int fileIndexStart = folderIndexStart + folderDictionary.Count * IndexBlockSize;
            int contentStart = fileIndexStart + IndexBlockSize * archive.Files.Count;
            int currentFolderIndex = 0;
            int currentFileIndex = 0;
            int currentContentLength = 0;
            foreach (string key in orderedKeys)
            {
                Ez2OnArchiveIndex folderIndex = new Ez2OnArchiveIndex();
                folderIndex.Name = key;
                folderIndex.Length = folderDictionary[key].Count;
                folderIndex.Position = folderIndexStart + currentFolderIndex;
                if (folderIndex.Length > 0)
                {
                    folderIndex.Offset = fileIndexStart + currentFileIndex;
                }
                else
                {
                    folderIndex.Offset = 0;
                }
                WriteIndex(buffer, folderIndex);
                foreach (Ez2OnArchiveFile file in folderDictionary[key])
                {
                    Ez2OnArchiveIndex fileIndex = new Ez2OnArchiveIndex();
                    fileIndex.Name = file.Name;
                    fileIndex.Length = file.Data.Length;
                    fileIndex.Position = fileIndexStart + currentFileIndex;
                    fileIndex.Offset = contentStart + currentContentLength;
                    WriteIndex(buffer, fileIndex);
                    buffer.WriteBytes(file.Data, 0, fileIndex.Offset, fileIndex.Length);
                    currentFileIndex += IndexBlockSize;
                    currentContentLength += file.Data.Length;
                    OnProgressChanged("WRITE", folderIndex.Name, totalFiles, currentFile++);
                }
                currentFolderIndex += IndexBlockSize;
            }
            archive.ContentOffset = contentStart;
            archive.FolderCount = folderDictionary.Count;
            archive.IndexOffset = folderIndexStart;
            buffer.Position = 0;
            if (archive.ArchiveType == Ez2OnArchiveType.Dat)
            {
                buffer.WriteCString(string.Format("{0:" + DateFormat + "}", archive.Created));
            }
            buffer.WriteCString(archive.Format);
            buffer.WriteInt32((int)archive.CryptoType);
            buffer.WriteInt32(archive.ContentOffset);
            buffer.WriteInt32(archive.FolderCount);
            buffer.WriteInt32(archive.IndexOffset);
            Utils.WriteFile(buffer.GetAllBytes(), destinationPath);
        }

        public void WriteFolder(Ez2OnArchiveFolder folder, string path)
        {
            string directoryPath = Path.Combine(path, folder.Name);
            Utils.EnsureDirectory(directoryPath);
            int currentFile = 0;
            foreach (Ez2OnArchiveFile file in folder.Files)
            {
                string filePath = Path.Combine(directoryPath, file.Name);
                Utils.WriteFile(file.Data, filePath);
                OnProgressChanged("WRITE", filePath, folder.Files.Count, currentFile++);
            }
            foreach (Ez2OnArchiveFolder subFolder in folder.Folders)
            {
                WriteFolder(subFolder, directoryPath);
            }
        }

        private Ez2OnArchiveIndex ReadIndex(IBuffer data)
        {
            Ez2OnArchiveIndex index = new Ez2OnArchiveIndex();
            index.Position = data.Position;
            byte[] nameBytes = data.ReadBytesFixedTerminated(MaxNameLength, 0);
            index.Name = KoreanEncoding.GetString(nameBytes);
            data.Position = index.Position + MaxNameLength;
            index.Length = data.ReadInt32();
            index.Offset = data.ReadInt32();
            return index;
        }

        private void WriteIndex(IBuffer buffer, Ez2OnArchiveIndex index)
        {
            buffer.Position = index.Position;
            byte[] nameBytes = KoreanEncoding.GetBytes(index.Name);
            if (nameBytes.Length > MaxNameLength)
            {
                // Error
            }
            buffer.WriteBytes(nameBytes);
            buffer.Position = index.Position + MaxNameLength;
            buffer.WriteInt32(index.Length);
            buffer.WriteInt32(index.Offset);
        }

        private void OnProgressChanged(string action, string message, int total, int current)
        {
            EventHandler<Ez2OnArchiveIOEventArgs> progressChanged = ProgressChanged;
            if (progressChanged != null)
            {
                Ez2OnArchiveIOEventArgs hdrProgressEventArgs = new Ez2OnArchiveIOEventArgs(action, message, total, current);
                progressChanged(this, hdrProgressEventArgs);
            }
        }
    }
}