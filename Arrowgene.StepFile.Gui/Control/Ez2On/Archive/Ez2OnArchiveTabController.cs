using Arrowgene.Services.Extra;
using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;
using Arrowgene.StepFile.Gui.Core.Ez2On.Archive;
using Arrowgene.StepFile.Gui.Plugin;
using Arrowgene.StepFile.Gui.Windows.SelectOption;
using Arrowgene.StepFile.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.Archive
{
    /// <summary>
    /// 2) File Preview
    /// 3) Warn unsaved progress
    /// 4) Rename directory / file
    /// 5) New directory
    /// </summary>
    public class Ez2OnArchiveTabController : ArchiveTabController
    {

        private Ez2OnArchive _archive;
        private Ez2OnArchiveTabFolder _root;
        private Ez2OnArchiveTabFolder _currentFolder;
        private Ez2OnArchiveTabFile _currentFile;
        private ArchiveTabItem _currentSelection;
        private Ez2OnArchiveTabControl _ez2OnArchiveTabControl;
        private ICollection<Ez2OnArchiveCrypto> _cryptos;
        private byte[] _crypoKey;

        private CommandHandler _cmdAddEncryption;
        private CommandHandler _cmdAddFile;
        private CommandHandler _cmdSave;
        private CommandHandler _cmdAddFolder;
        private CommandHandler _cmdRemoveEncryption;
        private CommandHandler _cmdExtract;
        private CommandHandler _cmdDelete;

        public Ez2OnArchiveTabController() : base(new Ez2OnArchiveTabControl())
        {
            _cryptos = new List<Ez2OnArchiveCrypto>();
            _ez2OnArchiveTabControl = TabUserControl as Ez2OnArchiveTabControl;
            Header = "Ez2On Archive";

            LoadArchiveCryptos();

            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "ItemName", ContentField = "ItemName" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", TextField = "Name" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "Extension", TextField = "Extension" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "DirectoryPath", TextField = "DirectoryPath" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "FullPath", TextField = "FullPath" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "Offset", TextField = "Offset" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "Length", TextField = "Length" });
            _ez2OnArchiveTabControl.AddColumn(new DynamicGridViewColumn { Header = "Encrypted", TextField = "Encrypted" });

            _ez2OnArchiveTabControl.NewArchiveCommand = new CommandHandler(NewArchiveCommand, true);
            _ez2OnArchiveTabControl.OpenArchiveCommand = new CommandHandler(OpenArchiveCommand, true);
            _ez2OnArchiveTabControl.SaveArchiveCommand = _cmdSave = new CommandHandler(SaveArchiveCommand, CanSave);
            _ez2OnArchiveTabControl.AddFileCommand = _cmdAddFile = new CommandHandler(AddFileCommand, CanAddFile);
            _ez2OnArchiveTabControl.AddFolderCommand = _cmdAddFolder = new CommandHandler(AddFolderCommand, CanAddFolder);
            _ez2OnArchiveTabControl.ExtractSelectionCommand = _cmdExtract = new CommandHandler(ExtractSelectionCommand, CanExtract);
            _ez2OnArchiveTabControl.DeleteSelectionCommand = _cmdDelete = new CommandHandler(DeleteSelectionCommand, CanDelete);
            _ez2OnArchiveTabControl.AddEncryptionCommand = _cmdAddEncryption = new CommandHandler(AddEncryptionCommand, CanAddEncryption);
            _ez2OnArchiveTabControl.RemoveEncryptionCommand = _cmdRemoveEncryption = new CommandHandler(RemoveEncryptionCommand, CanRemoveEncryptiony);
            _ez2OnArchiveTabControl.GenerateKeyCommand = new CommandHandler(GenerateKeyCommand, true);
            _ez2OnArchiveTabControl.BatchAddEncryptionCommand = new CommandHandler(BatchAddEncryptionCommand, true);
            _ez2OnArchiveTabControl.BatchRemoveEncryptionCommand = new CommandHandler(BatchRemoveEncryptionCommand, true);

            _ez2OnArchiveTabControl.ListViewItems.MouseDoubleClick += ListViewItems_MouseDoubleClick;
            _ez2OnArchiveTabControl.ListViewItems.SelectionChanged += ListViewItems_SelectionChanged;
            _ez2OnArchiveTabControl.ListViewItems.AllowDrop = true;
            _ez2OnArchiveTabControl.ListViewItems.Drop += ListViewItems_Drop;
            _ez2OnArchiveTabControl.ListViewItems.SelectionMode = SelectionMode.Single;
            _ez2OnArchiveTabControl.ListViewItems.IsEnabled = false;

            RaiseCmdChanged();
        }

        public async Task Open(FileInfo selected)
        {
            if (selected == null)
            {
                return;
            }
            Header = selected.Name;
            Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();
            archiveIO.ProgressChanged += ArchiveIO_ProgressChanged;
            var task = Task.Run(() =>
            {
                Ez2OnArchive archive = archiveIO.Read(selected.FullName);
                Ez2OnArchiveTabFolder root = new Ez2OnArchiveTabFolder(archive.RootFolder);
                return new Tuple<Ez2OnArchive, Ez2OnArchiveTabFolder>(archive, root);
            });
            Tuple<Ez2OnArchive, Ez2OnArchiveTabFolder> result = await task;
            _archive = result.Item1;
            _root = result.Item2;
            _currentFolder = _root;
            if (_archive.CryptoType == Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                _ez2OnArchiveTabControl.Encryption = "None";
            }
            else
            {
                Ez2OnArchiveCrypto activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                _ez2OnArchiveTabControl.Encryption = activeCrypto == null ? "Unknown" : activeCrypto.Name;
            }
            _crypoKey = null;
            _ez2OnArchiveTabControl.ArchiveType = _archive.ArchiveType;
            _ez2OnArchiveTabControl.ClearItems();
            _ez2OnArchiveTabControl.AddItemRange(_root.Folders);
            _ez2OnArchiveTabControl.AddItemRange(_root.Files);
            _ez2OnArchiveTabControl.ListViewItems.IsEnabled = true;

            RaiseCmdChanged();
            App.ResetProgress(this);
        }

        private void NewArchiveCommand()
        {
            Ez2OnArchiveType? archiveType = new SelectOptionBuilder<Ez2OnArchiveType?>()
                .SetTitle("Select Archive Type")
                .AddOption(Ez2OnArchiveType.Tro, "Tro (Data Archive)")
                .AddOption(Ez2OnArchiveType.Dat, "Dat (Music Archive)")
                .Select();
            if (archiveType == null)
            {
                return;
            }
            _archive = new Ez2OnArchive();
            _archive.ArchiveType = (Ez2OnArchiveType)archiveType;
            _root = new Ez2OnArchiveTabFolder(_archive.RootFolder);
            _currentFolder = _root;
            _ez2OnArchiveTabControl.Encryption = "None";
            _crypoKey = null;
            _ez2OnArchiveTabControl.ArchiveType = _archive.ArchiveType;
            _ez2OnArchiveTabControl.ClearItems();
            _ez2OnArchiveTabControl.AddItemRange(_root.Folders);
            _ez2OnArchiveTabControl.AddItemRange(_root.Files);
            _ez2OnArchiveTabControl.ListViewItems.IsEnabled = true;

            RaiseCmdChanged();
        }

        private async void OpenArchiveCommand()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On Archive files(*.dat, *.tro) | *.dat; *.tro")
                .SelectSingle();
           await Open(selected);
        }

        private async void SaveArchiveCommand()
        {
            SaveFileBuilder saveFileBuilder = new SaveFileBuilder();
            switch (_archive.ArchiveType)
            {
                case Ez2OnArchiveType.Dat:
                    saveFileBuilder.Filter("Ez2On Music Archive (.dat)|*.dat");
                    break;
                case Ez2OnArchiveType.Tro:
                    saveFileBuilder.Filter("Ez2On Data Archive (.tro)|*.tro");
                    break;
                default:
                    MessageBox.Show($"Can not save file. Invalid extension. Only '.tro' and '.dat' supported", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
            }
            FileInfo selected = saveFileBuilder.Select();
            if (selected == null)
            {
                return;
            }
            Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();
            archiveIO.ProgressChanged += ArchiveIO_ProgressChanged;
            var task = Task.Run(() =>
            {
                archiveIO.Write(_archive, selected.FullName);
            });
            await task;
            App.ResetProgress(this);
        }


        private bool CanSave()
        {
            if (_archive == null)
            {
                return false;
            }
            return true;
        }

        private void AddFileCommand()
        {
            Ez2OnArchiveCrypto activeCrypto = null;
            if (_archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                if (activeCrypto == null)
                {
                    MessageBox.Show($"Can not add file. Archive is encrypted with an unknown encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!activeCrypto.CanEncrypt)
                {
                    MessageBox.Show($"Can not add file. Encryption is not supported for '{activeCrypto.Name}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            List<FileInfo> selected = new SelectFileBuilder()
                .Filter("Add files(*.*) | *.*")
                .SelectMulti();
            if (selected == null || selected.Count <= 0)
            {
                return;
            }
            foreach (FileInfo fileInfo in selected)
            {
                Ez2OnArchiveTabFile tabFile = CreateFile(fileInfo, activeCrypto, _currentFolder, _archive.ArchiveType);
                if (tabFile == null)
                {
                    continue;
                }
                _archive.Files.Add(tabFile.File);
                _currentFolder.AddFile(tabFile);
                _ez2OnArchiveTabControl.AddItems(tabFile);
            }
        }

        private bool CanAddFile()
        {
            if (_archive == null)
            {
                return false;
            }
            return true;
        }

        private void AddFolderCommand()
        {
            DirectoryInfo selectedDestination = new SelectFolderBuilder()
                .Select();
            if (selectedDestination == null)
            {
                return;
            }
            Ez2OnArchiveCrypto activeCrypto = null;
            if (_archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                if (activeCrypto == null)
                {
                    MessageBox.Show($"Can not add folder. Archive is encrypted with an unknown encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!activeCrypto.CanEncrypt)
                {
                    MessageBox.Show($"Can not add folder. Encryption is not supported for '{activeCrypto.Name}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            Ez2OnArchiveTabFolder tabFolder = CreateDirectory(selectedDestination, activeCrypto, _currentFolder, _archive.ArchiveType);
            _currentFolder.Folders.Add(tabFolder);
            _currentFolder.Folder.Folders.Add(tabFolder.Folder);
            _ez2OnArchiveTabControl.AddItems(tabFolder);
            AddToCurrentArchive(tabFolder);
        }

        private bool CanAddFolder()
        {
            if (_archive == null)
            {
                return false;
            }
            return true;
        }

        private void DeleteSelectionCommand()
        {
            if (_currentFile != null)
            {
                _currentFolder.RemoveFile(_currentFile);
                _archive.Files.Remove(_currentFile.File);
                _ez2OnArchiveTabControl.RemoveItems(_currentFile);
                _currentFile = null;
            }
        }

        private bool CanDelete()
        {
            return _currentFile != null;
        }

        private async void ExtractSelectionCommand()
        {
            DirectoryInfo selected = new SelectFolderBuilder()
                .Select();
            if (selected == null)
            {
                return;
            }
            if (_currentSelection is Ez2OnArchiveTabFolder)
            {
                Ez2OnArchiveTabFolder folder = _currentSelection as Ez2OnArchiveTabFolder;
                Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();
                archiveIO.ProgressChanged += ArchiveIO_ProgressChanged;
                var task = Task.Run(() =>
                {
                    archiveIO.WriteFolder(folder.Folder, selected.FullName);
                });
                await task;
                App.ResetProgress(this);
            }
            else if (_currentSelection is Ez2OnArchiveTabFile)
            {
                Ez2OnArchiveTabFile file = _currentSelection as Ez2OnArchiveTabFile;
                string path = Path.Combine(selected.FullName, file.Name);
                Utils.WriteFile(file.File.Data, path);
            }
            App.ResetProgress(this);
        }

        private bool CanExtract()
        {
            return _currentSelection != null && _currentFolder != null && _currentSelection != _currentFolder.Parent;
        }

        private async void AddEncryptionCommand()
        {
            Ez2OnArchiveCrypto activeCrypto = null;
            if (_archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                if (activeCrypto == null)
                {
                    MessageBox.Show($"Can not encrypt archive. Archive is encrypted with an unknown encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    MessageBox.Show($"Can not encrypt archive. Archive is encrypted with '{activeCrypto.Name}' encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            SelectOptionBuilder<Ez2OnArchiveCrypto> selectOption = new SelectOptionBuilder<Ez2OnArchiveCrypto>()
                .SetTitle("Select Crypto")
                .SetText("Choose a crypto to apply");
            bool hasCrypto = false;
            foreach (Ez2OnArchiveCrypto crypto in _cryptos)
            {
                if (crypto.CanEncrypt)
                {
                    selectOption.AddOption(crypto, crypto.Name);
                    hasCrypto = true;
                }
            }
            if (!hasCrypto)
            {
                MessageBox.Show($"Can not encrypt archive. No suitable encryption plugin available", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Ez2OnArchiveCrypto selectedCrypto = selectOption.Select();
            if (selectedCrypto == null)
            {
                return;
            }
            if (selectedCrypto.CryptoPlugin is ICryptoPlugin)
            {
                ICryptoPlugin selectedICryptoPlugin = (ICryptoPlugin)selectedCrypto.CryptoPlugin;
                FileInfo selected = new SelectFileBuilder()
                    .Filter("Ez2On Archive Key file(*.key) | *.key")
                    .SelectSingle();
                if (selected == null)
                {
                    return;
                }
                _crypoKey = Utils.ReadFile(selected.FullName);
                selectedICryptoPlugin.SetKey(_crypoKey);
            }
            int total = _archive.Files.Count;
            int current = 0;
            var task = Task.Run(() =>
            {
                foreach (Ez2OnArchiveFile file in _archive.Files)
                {
                    float progress = current++ / (float)total * 100;
                    App.UpdateProgress(this, (int)progress, $"Encrypting: {file.FullPath}");
                    selectedCrypto.Encrypt(file, _archive.ArchiveType);
                }
            });
            await task;
            _archive.CryptoType = selectedCrypto.CryptoType;
            _ez2OnArchiveTabControl.Encryption = selectedCrypto.Name;

            RaiseCmdChanged();
            App.ResetProgress(this);
            MessageBox.Show($"Added '{selectedCrypto.Name}' encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanAddEncryption()
        {
            if (_archive == null)
            {
                return false;
            }
            return true;
        }

        private async void RemoveEncryptionCommand()
        {
            if (_archive.CryptoType == Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                MessageBox.Show($"Can not remove encryption. Archive is not encrypted", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Ez2OnArchiveCrypto activeCrypto = GetArchiveCrypto(_archive.CryptoType);
            if (activeCrypto == null)
            {
                MessageBox.Show($"Can not remove encryption. Archive is encrypted with an unknown encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!activeCrypto.CanDecrypt)
            {
                MessageBox.Show($"Can not remove encryption. '{activeCrypto.Name}' does not support decryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (activeCrypto.CryptoPlugin is ICryptoPlugin)
            {
                ICryptoPlugin selectedICryptoPlugin = (ICryptoPlugin)activeCrypto.CryptoPlugin;
                if (_crypoKey == null)
                {
                    FileInfo selected = new SelectFileBuilder()
                        .Filter("Ez2On Archive Key file(*.key) | *.key")
                        .SelectSingle();
                    if (selected == null)
                    {
                        return;
                    }
                    _crypoKey = Utils.ReadFile(selected.FullName);
                }
                selectedICryptoPlugin.SetKey(_crypoKey);
            }
            int total = _archive.Files.Count;
            int current = 0;
            var task = Task.Run(() =>
            {
                foreach (Ez2OnArchiveFile file in _archive.Files)
                {
                    float progress = current++ / (float)total * 100;
                    App.UpdateProgress(this, (int)progress, $"Decrypting: {file.FullPath}");
                    activeCrypto.Decrypt(file, _archive.ArchiveType);
                }
            });
            await task;
            _archive.CryptoType = Ez2OnArchive.CRYPTO_TYPE_NONE;
            _ez2OnArchiveTabControl.Encryption = "None";
            _crypoKey = null;

            RaiseCmdChanged();
            App.ResetProgress(this);
            MessageBox.Show($"Removed '{activeCrypto.Name}' Encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanRemoveEncryptiony()
        {
            if (_archive == null)
            {
                return false;
            }
            return true;
        }

        private void GenerateKeyCommand()
        {
            SelectOptionBuilder<ICryptoPlugin> selectOption = new SelectOptionBuilder<ICryptoPlugin>()
                .SetTitle("Select Crypto")
                .SetText("Choose a crypto to generate a key");
            bool hasCrypto = false;
            foreach (Ez2OnArchiveCrypto crypto in _cryptos)
            {
                if (crypto.CryptoPlugin is ICryptoPlugin)
                {
                    selectOption.AddOption((ICryptoPlugin)crypto.CryptoPlugin, crypto.Name);
                    hasCrypto = true;
                }
            }
            if (!hasCrypto)
            {
                MessageBox.Show($"No Crypto with key generation available", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            ICryptoPlugin selectedCrypto = selectOption.Select();
            if (selectedCrypto == null)
            {
                return;
            }
            byte[] key = Utils.GenerateKey(selectedCrypto.KeyLength);
            FileInfo selected = new SaveFileBuilder()
                .Filter("Ez2On Archive Key file(*.key) | *.key")
                .Select();
            if (selected == null)
            {
                return;
            }
            Utils.WriteFile(key, selected.FullName);
            MessageBox.Show("New Key Saved", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void BatchRemoveEncryptionCommand()
        {
            List<FileInfo> selectedArchives = new SelectFileBuilder()
                .Filter("Ez2On Data Archive (.tro)|*.tro|Ez2On Music Archive (.dat)|*.dat")
                .SelectMulti();
            if (selectedArchives == null || selectedArchives.Count <= 0)
            {
                return;
            }
            DirectoryInfo selectedDestination = new SelectFolderBuilder()
                .Select();
            if (selectedDestination == null)
            {
                return;
            }
            Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();
            archiveIO.ProgressChanged += ArchiveIO_ProgressChanged;
            List<string> errors = new List<string>();
            var task = Task.Run(() =>
            {
                int totalArchives = selectedArchives.Count;
                int currentArchive = 0;
                byte[] key = null;
                foreach (FileInfo selectedArchive in selectedArchives)
                {
                    currentArchive++;
                    Ez2OnArchive archive = archiveIO.Read(selectedArchive.FullName);
                    if (archive.CryptoType == Ez2OnArchive.CRYPTO_TYPE_NONE)
                    {
                        errors.Add($"'{selectedArchive.FullName}': Can not remove encryption. Archive is not encrypted");
                        continue;
                    }
                    Ez2OnArchiveCrypto activeCrypto = GetArchiveCrypto(archive.CryptoType);
                    if (activeCrypto == null)
                    {
                        errors.Add($"'{selectedArchive.FullName}': Can not remove encryption. Archive is encrypted with an unknown encryption");
                        continue;
                    }
                    if (!activeCrypto.CanDecrypt)
                    {
                        errors.Add($"'{selectedArchive.FullName}': Can not remove encryption. '{activeCrypto.Name}' does not support decryption");
                        continue;
                    }
                    if (activeCrypto.CryptoPlugin is ICryptoPlugin)
                    {
                        if (key == null)
                        {
                            FileInfo selectedKey = new SelectFileBuilder().Filter("Ez2On Archive Key file(*.key) | *.key").SelectSingle();
                            if (selectedKey == null)
                            {
                                errors.Add($"'{selectedArchive.FullName}': No key selected for decryption");
                                continue;
                            }
                            key = Utils.ReadFile(selectedKey.FullName);
                        }
                        ICryptoPlugin selectedICryptoPlugin = (ICryptoPlugin)activeCrypto.CryptoPlugin;
                        selectedICryptoPlugin.SetKey(key);
                    }
                    int total = archive.Files.Count;
                    int current = 0;
                    float progress = 0;
                    foreach (Ez2OnArchiveFile file in archive.Files)
                    {
                        progress = current++ / (float)total * 100;
                        App.UpdateProgress(this, (int)progress, $"({currentArchive}/{totalArchives}) - {selectedArchive.FullName}: Decrypting: {file.FullPath}");
                        activeCrypto.Decrypt(file, archive.ArchiveType);
                    }
                    archive.CryptoType = Ez2OnArchive.CRYPTO_TYPE_NONE;
                    string destination = Path.Combine(selectedDestination.FullName, selectedArchive.Name);
                    archiveIO.Write(archive, destination);
                    App.UpdateProgress(this, (int)progress, $"({currentArchive}/{totalArchives}) - {selectedArchive.FullName}");
                }
            });
            await task;
            App.ResetProgress(this);
            if (errors.Count > 0)
            {
                string error = "";
                for (int i = 0; i < errors.Count && i < 10; i++)
                {
                    error += errors[i] + Environment.NewLine;
                }
                MessageBox.Show(error, "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Operation Completed", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void BatchAddEncryptionCommand()
        {
            SelectOptionBuilder<Ez2OnArchiveCrypto> selectOption = new SelectOptionBuilder<Ez2OnArchiveCrypto>()
                .SetTitle("Select Crypto")
                .SetText("Choose a crypto to apply");
            bool hasCrypto = false;
            foreach (Ez2OnArchiveCrypto crypto in _cryptos)
            {
                if (crypto.CanEncrypt)
                {
                    selectOption.AddOption(crypto, crypto.Name);
                    hasCrypto = true;
                }
            }
            if (!hasCrypto)
            {
                MessageBox.Show($"Can not encrypt archive. No suitable encryption plugin available", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Ez2OnArchiveCrypto selectedCrypto = selectOption.Select();
            if (selectedCrypto == null)
            {
                return;
            }
            byte[] key = null;
            if (selectedCrypto.CryptoPlugin is ICryptoPlugin)
            {
                ICryptoPlugin selectedICryptoPlugin = (ICryptoPlugin)selectedCrypto.CryptoPlugin;
                FileInfo selected = new SelectFileBuilder()
                    .Filter("Ez2On Archive Key file(*.key) | *.key")
                    .SelectSingle();
                if (selected == null)
                {
                    return;
                }
                key = Utils.ReadFile(selected.FullName);
                selectedICryptoPlugin.SetKey(key);
            }
            List<FileInfo> selectedArchives = new SelectFileBuilder()
                        .Filter("Ez2On Data Archive (.tro)|*.tro|Ez2On Music Archive (.dat)|*.dat")
                        .SelectMulti();
            if (selectedArchives == null || selectedArchives.Count <= 0)
            {
                return;
            }
            DirectoryInfo selectedDestination = new SelectFolderBuilder()
                .Select();
            if (selectedDestination == null)
            {
                return;
            }
            Ez2OnArchiveIO archiveIO = new Ez2OnArchiveIO();
            archiveIO.ProgressChanged += ArchiveIO_ProgressChanged;
            List<string> errors = new List<string>();
            var task = Task.Run(() =>
            {
                int totalArchives = selectedArchives.Count;
                int currentArchive = 0;
                foreach (FileInfo selectedArchive in selectedArchives)
                {
                    currentArchive++;
                    Ez2OnArchive archive = archiveIO.Read(selectedArchive.FullName);
                    Ez2OnArchiveCrypto activeCrypto = null;
                    if (archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE)
                    {
                        activeCrypto = GetArchiveCrypto(archive.CryptoType);
                        if (activeCrypto == null)
                        {
                            errors.Add($"'{selectedArchive.FullName}': Can not encrypt archive. Archive is encrypted with an unknown encryption");
                            continue;
                        }
                        else
                        {
                            errors.Add($"'{selectedArchive.FullName}': Can not encrypt archive. Archive is encrypted with '{activeCrypto.Name}' encryption");
                            continue;
                        }
                    }
                    int total = archive.Files.Count;
                    int current = 0;
                    float progress = 0;
                    foreach (Ez2OnArchiveFile file in archive.Files)
                    {
                        progress = current++ / (float)total * 100;
                        App.UpdateProgress(this, (int)progress, $"({currentArchive}/{totalArchives}) - {selectedArchive.FullName}: Encrypting: {file.FullPath}");
                        selectedCrypto.Encrypt(file, archive.ArchiveType);
                    }
                    archive.CryptoType = selectedCrypto.CryptoType;
                    string destination = Path.Combine(selectedDestination.FullName, selectedArchive.Name);
                    archiveIO.Write(archive, destination);
                    App.UpdateProgress(this, (int)progress, $"({currentArchive}/{totalArchives}) - {selectedArchive.FullName}");
                }
            });
            await task;
            App.ResetProgress(this);
            if (errors.Count > 0)
            {
                string error = "";
                for (int i = 0; i < errors.Count && i < 10; i++)
                {
                    error += errors[i] + Environment.NewLine;
                }
                MessageBox.Show(error, "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Operation Completed", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ListViewItems_Drop(object sender, DragEventArgs e)
        {
            Ez2OnArchiveCrypto activeCrypto = null;
            if (_archive.CryptoType != Ez2OnArchive.CRYPTO_TYPE_NONE)
            {
                activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                if (activeCrypto == null)
                {
                    MessageBox.Show($"Can not add file. Archive is encrypted with an unknown encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!activeCrypto.CanEncrypt)
                {
                    MessageBox.Show($"Can not add file. Encryption is not supported for '{activeCrypto.Name}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string drop in dropped)
                {
                    if (File.Exists(drop))
                    {
                        FileInfo file = App.CreateFileInfo(drop);
                        if (file == null)
                        {
                            continue;
                        }
                        Ez2OnArchiveTabFile tabFile = CreateFile(file, activeCrypto, _currentFolder, _archive.ArchiveType);
                        if (tabFile == null)
                        {
                            continue;
                        }
                        _archive.Files.Add(tabFile.File);
                        _currentFolder.AddFile(tabFile);
                        _ez2OnArchiveTabControl.AddItems(tabFile);
                    }
                    else if (Directory.Exists(drop))
                    {
                        DirectoryInfo directory = App.CreateDirectoryInfo(drop);
                        Ez2OnArchiveTabFolder tabFolder = CreateDirectory(directory, activeCrypto, _currentFolder, _archive.ArchiveType);
                        _currentFolder.Folders.Add(tabFolder);
                        _currentFolder.Folder.Folders.Add(tabFolder.Folder);
                        _ez2OnArchiveTabControl.AddItems(tabFolder);
                        AddToCurrentArchive(tabFolder);
                    }
                    else
                    {
                        _logger.Error($"Can not handle dropped: {drop}");
                    }
                }
            }
        }

        private void ArchiveIO_ProgressChanged(object sender, Ez2OnArchiveIOEventArgs e)
        {
            float progress = e.Current / (float)e.Total * 100;
            App.UpdateProgress(this, (int)progress, e.Message);
        }

        private void ListViewItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ez2OnArchiveTabFolder selectedFolder = _ez2OnArchiveTabControl.ListViewItems.SelectedItem as Ez2OnArchiveTabFolder;
            if (selectedFolder == null)
            {
                return;
            }
            _ez2OnArchiveTabControl.ClearItems();
            if (_currentFolder.Parent != null)
            {
                _currentFolder.Parent.UpNavigation = false;
            }
            if (selectedFolder.Parent != null)
            {
                selectedFolder.Parent.UpNavigation = true;
                _ez2OnArchiveTabControl.AddItems(selectedFolder.Parent);
            }
            _ez2OnArchiveTabControl.AddItemRange(selectedFolder.Folders);
            _ez2OnArchiveTabControl.AddItemRange(selectedFolder.Files);
            _currentFolder = selectedFolder;
            _ez2OnArchiveTabControl.FilePath = selectedFolder.FullPath;
        }

        private void ListViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArchiveTabItem selection = _ez2OnArchiveTabControl.ListViewItems.SelectedItem as ArchiveTabItem;
            _currentSelection = selection;
            Ez2OnArchiveTabFile selectedFile = _ez2OnArchiveTabControl.ListViewItems.SelectedItem as Ez2OnArchiveTabFile;
            _currentFile = selectedFile;

            RaiseCmdChanged();
        }

        private void LoadArchiveCryptos()
        {
            foreach (IEz2OnArchiveCryptoPlugin archiveCryptoPlugin in PluginRegistry.Instance.GetPlugins<IEz2OnArchiveCryptoPlugin>())
            {
                _cryptos.Add(new Ez2OnArchiveCrypto(archiveCryptoPlugin));
            }
        }

        private Ez2OnArchiveCrypto GetArchiveCrypto(int cryptoType)
        {
            foreach (Ez2OnArchiveCrypto crypto in _cryptos)
            {
                if (crypto.CryptoType == cryptoType)
                {
                    return crypto;
                }
            }
            return null;
        }

        private Ez2OnArchiveTabFolder CreateDirectory(DirectoryInfo directoryInfo, Ez2OnArchiveCrypto activeCrypto, Ez2OnArchiveTabFolder parentTabFolder, Ez2OnArchiveType archiveType)
        {
            Ez2OnArchiveFolder folder = new Ez2OnArchiveFolder();
            folder.SetFullPath(parentTabFolder.FullPath + directoryInfo.Name);
            Ez2OnArchiveTabFolder tabFolder = new Ez2OnArchiveTabFolder(folder);
            tabFolder.Parent = parentTabFolder;
            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                Ez2OnArchiveTabFile tabFile = CreateFile(fileInfo, activeCrypto, tabFolder, archiveType);
                if (tabFile == null)
                {
                    continue;
                }
                tabFolder.AddFile(tabFile);
            }
            foreach (DirectoryInfo subFolder in directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                Ez2OnArchiveTabFolder subTabFolder = CreateDirectory(subFolder, activeCrypto, tabFolder, archiveType);
                subTabFolder.Parent = tabFolder;
                tabFolder.Folders.Add(subTabFolder);
                tabFolder.Folder.Folders.Add(subTabFolder.Folder);
            }
            return tabFolder;
        }

        private Ez2OnArchiveTabFile CreateFile(FileInfo fileInfo, Ez2OnArchiveCrypto activeCrypto, Ez2OnArchiveTabFolder tabFolder, Ez2OnArchiveType archiveType)
        {
            byte[] file = Utils.ReadFile(fileInfo.FullName);
            Ez2OnArchiveFile archiveFile = new Ez2OnArchiveFile();
            archiveFile.Data = file;
            archiveFile.Name = fileInfo.Name;
            archiveFile.Length = file.Length;
            archiveFile.Extension = fileInfo.Extension;
            archiveFile.DirectoryPath = tabFolder.FullPath;
            archiveFile.FullPath = tabFolder.FullPath + fileInfo.Name;
            if (activeCrypto != null)
            {
                if (activeCrypto.CryptoPlugin is ICryptoPlugin)
                {
                    ICryptoPlugin selectedICryptoPlugin = (ICryptoPlugin)activeCrypto.CryptoPlugin;
                    if (_crypoKey == null)
                    {
                        FileInfo selectedKey = new SelectFileBuilder()
                            .Filter("Ez2On Archive Key file(*.key) | *.key")
                            .SelectSingle();
                        if (selectedKey == null)
                        {
                            return null;
                        }
                        _crypoKey = Utils.ReadFile(selectedKey.FullName);
                    }
                    selectedICryptoPlugin.SetKey(_crypoKey);
                }
                activeCrypto.Encrypt(archiveFile, archiveType);
            }
            Ez2OnArchiveTabFile tabFile = new Ez2OnArchiveTabFile(archiveFile);
            return tabFile;
        }

        private void AddToCurrentArchive(Ez2OnArchiveTabFolder parentTabFolder)
        {
            foreach (Ez2OnArchiveTabFile tabFile in parentTabFolder.Files)
            {
                _archive.Files.Add(tabFile.File);
            }
            foreach (Ez2OnArchiveTabFolder tabFolder in parentTabFolder.Folders)
            {
                AddToCurrentArchive(tabFolder);
            }
        }

        private void RaiseCmdChanged()
        {
            _cmdAddEncryption.RaiseCanExecuteChanged();
            _cmdAddFile.RaiseCanExecuteChanged();
            _cmdSave.RaiseCanExecuteChanged();
            _cmdAddFolder.RaiseCanExecuteChanged();
            _cmdRemoveEncryption.RaiseCanExecuteChanged();
            _cmdExtract.RaiseCanExecuteChanged();
            _cmdDelete.RaiseCanExecuteChanged();
        }
    }
}
