using System;
using System.Collections.Generic;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Archive
{
    public class Ez2OnArchive
    {
        public const string Hdr = "HDR";
        public const int CRYPTO_TYPE_NONE = 0;

        public Ez2OnArchiveType ArchiveType { get; set; }
        public int CryptoType { get; set; }
        public DateTime? Created { get; set; }
        public string Format { get; set; }
        public int ContentOffset { get; set; }
        public int FolderCount { get; set; }
        public int IndexOffset { get; set; }
        public List<Ez2OnArchiveFile> Files { get; }
        public Ez2OnArchiveFolder RootFolder { get; set; }

        public Ez2OnArchive()
        {
            Files = new List<Ez2OnArchiveFile>();
            RootFolder = new Ez2OnArchiveFolder();
            Created = DateTime.Now;
            CryptoType = CRYPTO_TYPE_NONE;
            Format = Ez2OnArchive.Hdr;
            ArchiveType = Ez2OnArchiveType.Tro;
        }

        public void AddFolder(Ez2OnArchiveFolder folder)
        {
            if (string.IsNullOrEmpty(folder.FullPath))
            {
                RootFolder = folder;
                return;
            }
            if (string.IsNullOrEmpty(folder.DirectoryPath))
            {
                RootFolder.Folders.Add(folder);
                return;
            }
            Ez2OnArchiveFolder parent = FindParent(RootFolder, folder);
            if (parent == null)
            {
                parent = ProvideParent(RootFolder, folder);
            }
            parent.Folders.Add(folder);
        }

        private Ez2OnArchiveFolder ProvideParent(Ez2OnArchiveFolder root, Ez2OnArchiveFolder child)
        {
            Ez2OnArchiveFolder currentFolder = root;
            string path = "";
            string[] folderNameParts = child.DirectoryPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int length = folderNameParts.Length;
            for (int i = 0; i < length; i++)
            {
                string current = folderNameParts[i];
                if (i == 0)
                {
                    path = current + '\\';
                }
                else
                {
                    path = path + current + '\\';
                }
                bool exists = false;
                foreach (Ez2OnArchiveFolder folder in currentFolder.Folders)
                {
                    if (folder.DirectoryPath == path)
                    {
                        currentFolder = folder;
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    Ez2OnArchiveFolder folder = new Ez2OnArchiveFolder();
                    folder.DirectoryPath = currentFolder.FullPath;
                    folder.Name = current;
                    folder.FullPath = path;
                    currentFolder.Folders.Add(folder);
                    currentFolder = folder;
                }
            }
            return currentFolder;
        }

        private Ez2OnArchiveFolder FindParent(Ez2OnArchiveFolder root, Ez2OnArchiveFolder child)
        {
            foreach (Ez2OnArchiveFolder folder in root.Folders)
            {
                if (folder.FullPath == child.DirectoryPath)
                {
                    return folder;
                }
                if (folder.Folders.Count > 0)
                {
                    Ez2OnArchiveFolder result = FindParent(folder, child);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

    }
}
