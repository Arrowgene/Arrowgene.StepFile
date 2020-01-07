using Arrowgene.Services.Extra;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.Archive;
using Arrowgene.StepFile.Gui.Plugin;
using Arrowgene.StepFile.Plugin;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.Build
{
    public class Ez2OnBuildTabController
    {
        private int _progress;
        private int _total;

        public Ez2OnBuildTabController()
        {
        }

        public async void Build()
        {
            DirectoryInfo selectedDestination = new SelectFolderBuilder().Select();
            if (selectedDestination == null)
            {
                return;
            }

            Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();

            DirectoryInfo output = new DirectoryInfo(Path.Combine(selectedDestination.FullName, "Out"));
            DirectoryInfo musicOutput = new DirectoryInfo(Path.Combine(output.FullName, "Music"));
            Directory.CreateDirectory(musicOutput.FullName);
            if (!musicOutput.Exists)
            {
                MessageBox.Show($"Could not create folder '{musicOutput.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            FileInfo key = new FileInfo(Path.Combine(selectedDestination.FullName, "ez2on.key"));
            if (!key.Exists)
            {
                MessageBox.Show($"Missing key '{key.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            byte[] crypoKey = Utils.ReadFile(key.FullName);

            Ez2OnArchiveCrypto archiveCrypto = null;
            foreach (IEz2OnArchiveCryptoPlugin archiveCryptoPlugin in PluginRegistry.Instance.GetPlugins<IEz2OnArchiveCryptoPlugin>())
            {
                if (archiveCryptoPlugin.CryptoType == 2 && archiveCryptoPlugin is ICryptoPlugin)
                {
                    ICryptoPlugin cryptoPlugin = archiveCryptoPlugin as ICryptoPlugin;
                    cryptoPlugin.SetKey(crypoKey);
                    archiveCrypto = new Ez2OnArchiveCrypto(archiveCryptoPlugin);
                }
            }
            if (archiveCrypto == null)
            {
                MessageBox.Show($"Missing Aes Crypto Plugin", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DirectoryInfo ezData = new DirectoryInfo(Path.Combine(selectedDestination.FullName, "Data/EzData"));
            if (!ezData.Exists)
            {
                MessageBox.Show($"Data/EzData Directory not found '{ezData.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var task = Task.Run(() =>
            {
                FileInfo troFileInfo = new FileInfo(Path.Combine(output.FullName, "EzData.tro"));
                _progress = 0;
                _total = 1;
                App.UpdateProgress(this, (int)(_progress / (float)_total * 100), $"Packing ({_progress}/{_total}) - {troFileInfo.Name}");
                Ez2OnArchive tro = new Ez2OnArchive();
                tro.ArchiveType = Ez2OnArchiveType.Tro;
                tro.CryptoType = archiveCrypto.CryptoType;
                tro.Created = DateTime.Now;
                tro.Format = Ez2OnArchive.Hdr;
                tro.RootFolder = CreateDirectory(ezData, tro, archiveCrypto, null);
                archiveIO.Write(tro, troFileInfo.FullName);
            });
            await task;
            DirectoryInfo music = new DirectoryInfo(Path.Combine(selectedDestination.FullName, "Data/Music"));
            if (!music.Exists)
            {
                MessageBox.Show($"/Data/Music Directory not found '{music.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            task = Task.Run(() =>
            {
                DirectoryInfo[] musicDirectories = music.GetDirectories("*", SearchOption.TopDirectoryOnly);
                _progress = 0;
                _total = musicDirectories.Length;
                foreach (DirectoryInfo musicDirectoryInfo in musicDirectories)
                {
                    _progress++;
                    FileInfo datFileInfo = new FileInfo(Path.Combine(musicOutput.FullName, musicDirectoryInfo.Name + ".dat"));
                    App.UpdateProgress(this, (int)(_progress / (float)_total * 100), $"Packing ({_progress}/{_total}) - {datFileInfo.Name}");
                    Ez2OnArchive dat = new Ez2OnArchive();
                    dat.ArchiveType = Ez2OnArchiveType.Dat;
                    dat.CryptoType = archiveCrypto.CryptoType;
                    dat.Created = DateTime.Now;
                    dat.Format = Ez2OnArchive.Hdr;
                    dat.RootFolder = CreateDirectory(musicDirectoryInfo, dat, archiveCrypto, new Ez2OnArchiveFolder());
                    archiveIO.Write(dat, datFileInfo.FullName);
                }
            });
            await task;

            DirectoryInfo data = new DirectoryInfo(Path.Combine(selectedDestination.FullName, "Data"));
            if (!data.Exists)
            {
                MessageBox.Show($"/Data Directory not found '{data.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            task = Task.Run(() =>
            {
                FileInfo[] files = data.GetFiles("*", SearchOption.TopDirectoryOnly);
                _progress = 0;
                _total = files.Length;
                foreach (FileInfo file in files)
                {
                    _progress++;
                    File.Copy(file.FullName, Path.Combine(output.FullName, file.Name));
                    App.UpdateProgress(this, (int)(_progress / (float)_total * 100), $"Writing Files ({_progress}/{_total}) - {file.Name}");
                }
            });
            await task;
            App.ResetProgress(this);
            MessageBox.Show($"Finished", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private Ez2OnArchiveFolder CreateDirectory(DirectoryInfo directoryInfo, Ez2OnArchive archive, Ez2OnArchiveCrypto activeCrypto, Ez2OnArchiveFolder parentFolder)
        {
            Ez2OnArchiveFolder folder = new Ez2OnArchiveFolder();
            if (parentFolder != null)
            {
                folder.SetFullPath(parentFolder.FullPath + directoryInfo.Name);
            }

            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                Ez2OnArchiveFile file = CreateFile(fileInfo, archive, folder, activeCrypto);
                folder.Files.Add(file);
                archive.Files.Add(file);
            }
            foreach (DirectoryInfo subFolder in directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                Ez2OnArchiveFolder subArchiveFolder = CreateDirectory(subFolder, archive, activeCrypto, folder);
                folder.Folders.Add(subArchiveFolder);
            }
            return folder;
        }

        private Ez2OnArchiveFile CreateFile(FileInfo fileInfo, Ez2OnArchive archive, Ez2OnArchiveFolder folder, Ez2OnArchiveCrypto archiveCrypto)
        {
            byte[] file = Utils.ReadFile(fileInfo.FullName);
            Ez2OnArchiveFile archiveFile = new Ez2OnArchiveFile();
            archiveFile.Data = file;
            archiveFile.Name = fileInfo.Name;
            archiveFile.Length = file.Length;
            archiveFile.Extension = fileInfo.Extension;
            archiveFile.DirectoryPath = folder.FullPath;
            archiveFile.FullPath = folder.FullPath + fileInfo.Name;
            archiveCrypto.Encrypt(archiveFile, archive.ArchiveType);
            return archiveFile;
        }

    }
}
