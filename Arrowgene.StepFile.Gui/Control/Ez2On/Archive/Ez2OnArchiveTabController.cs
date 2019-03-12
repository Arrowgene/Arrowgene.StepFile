using Arrowgene.Services.Extra;
using Arrowgene.StepFile.Control.ArchiveTab;
using Arrowgene.StepFile.Core;
using Arrowgene.StepFile.Core.DynamicGridView;
using Arrowgene.StepFile.Core.Ez2On.Archive;
using Arrowgene.StepFile.Plugin;
using Arrowgene.StepFile.Windows.SelectOption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.Ez2On.Archive
{
    public class Ez2OnArchiveTabController : ArchiveTabController
    {

        private Ez2OnArchive _archive;
        private Ez2OnArchiveTabFolder _root;
        private Ez2OnArchiveTabFolder _currentFolder;
        private Ez2OnArchiveTabFile _currentFile;
        private ArchiveTabItem _currentSelection;
        private Ez2OnArchiveTabControl _ez2OnArchiveTabControl;
        private ICollection<Ez2OnArchiveCrypto> _cryptos;

        private CommandHandler _cmdKeyAdd;
        private CommandHandler _cmdAdd;
        private CommandHandler _cmdKeyDelete;
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

            _ez2OnArchiveTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OnArchiveTabControl.SaveCommand = new CommandHandler(Save, true);
            _ez2OnArchiveTabControl.ExtractCommand = _cmdExtract = new CommandHandler(Extract, CanExtract);
            _ez2OnArchiveTabControl.DeleteCommand = _cmdDelete = new CommandHandler(Delete, CanDelete);
            _ez2OnArchiveTabControl.AddCommand = _cmdAdd = new CommandHandler(Add, CanAdd);
            _ez2OnArchiveTabControl.KeyAddCommand = _cmdKeyAdd = new CommandHandler(KeyAdd, CanAddKey);
            _ez2OnArchiveTabControl.KeyDeleteCommand = _cmdKeyDelete = new CommandHandler(KeyDelete, CanDeleteKey);
            _ez2OnArchiveTabControl.KeyGenerateCommand = new CommandHandler(KeyGenerate, true);


            _ez2OnArchiveTabControl.ListViewItems.MouseDoubleClick += ListViewItems_MouseDoubleClick;
            _ez2OnArchiveTabControl.ListViewItems.SelectionChanged += ListViewItems_SelectionChanged;

            _archive = new Ez2OnArchive();
            _root = new Ez2OnArchiveTabFolder(_archive.RootFolder);
            _currentFolder = _root;

            _cmdAdd.RaiseCanExecuteChanged();
            _cmdKeyAdd.RaiseCanExecuteChanged();
            _cmdKeyDelete.RaiseCanExecuteChanged();
            _cmdExtract.RaiseCanExecuteChanged();
            _cmdDelete.RaiseCanExecuteChanged();
        }

        public async void Open()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On Archive files(*.dat, *.tro) | *.dat; *.tro")
                .SelectSingle();
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
                Ez2OnArchiveCrypto _activeCrypto = GetArchiveCrypto(_archive.CryptoType);
                _ez2OnArchiveTabControl.Encryption = _activeCrypto == null ? "Unknown" : _activeCrypto.Name;
            }
            _ez2OnArchiveTabControl.ArchiveType = _archive.ArchiveType;
            _ez2OnArchiveTabControl.ClearItems();
            _ez2OnArchiveTabControl.AddItemRange(_root.Folders);
            _ez2OnArchiveTabControl.AddItemRange(_root.Files);
            _cmdAdd.RaiseCanExecuteChanged();
            _cmdKeyAdd.RaiseCanExecuteChanged();
            _cmdKeyDelete.RaiseCanExecuteChanged();
            _cmdExtract.RaiseCanExecuteChanged();
            _cmdDelete.RaiseCanExecuteChanged();
            App.ResetProgress(this);

        }

        private async void Save()
        {
            FileInfo selected = new SaveFileBuilder()
                .Filter("Ez2On Data Archive (.tro)|*.tro|Ez2On Music Archive (.dat)|*.dat")
                .Select();
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

        private void Add()
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
            FileInfo selected = new SelectFileBuilder()
                .Filter("Add files(*.*) | *.*")
                .SelectSingle();
            if (selected == null)
            {
                return;
            }
            byte[] file = Utils.ReadFile(selected.FullName);
            Ez2OnArchiveFile archiveFile = new Ez2OnArchiveFile();
            archiveFile.Data = file;
            archiveFile.Name = selected.Name;
            archiveFile.Length = file.Length;
            archiveFile.Extension = selected.Extension;
            archiveFile.DirectoryPath = _currentFolder.FullPath;
            archiveFile.FullPath = _currentFolder.FullPath + selected.Name;
            if (activeCrypto != null)
            {
                activeCrypto.Encrypt(archiveFile);
            }
            Ez2OnArchiveTabFile tabFile = new Ez2OnArchiveTabFile(archiveFile);
            _currentFolder.AddFile(tabFile);
            _archive.Files.Add(archiveFile);
            _ez2OnArchiveTabControl.Items.Add(tabFile);
        }

        private bool CanAdd()
        {
            if (_archive == null)
            {
                return false;
            }
            //  if (_archive.CryptoType == Ez2OnArchiveCryptoType.AesCrypto && _activeCrypto == null)
            //  {
            //      return false;
            //  }
            //  if (_archive.CryptoType == Ez2OnArchiveCryptoType.EzCrypto)
            //  {
            //      return false;
            //  }
            return true;
        }

        private void Delete()
        {
            if (_currentFile != null)
            {
                _currentFolder.RemoveFile(_currentFile);
                _archive.Files.Remove(_currentFile.File);
                _ez2OnArchiveTabControl.Items.Remove(_currentFile);
                _currentFile = null;
            }
        }

        private bool CanDelete()
        {
            return _currentFile != null;
        }

        private async void Extract()
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

        private async void KeyAdd()
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
                byte[] key = Utils.ReadFile(selected.FullName);
                selectedICryptoPlugin.SetKey(key);
            }
            int total = _archive.Files.Count;
            int current = 0;
            var task = Task.Run(() =>
            {
                foreach (Ez2OnArchiveFile file in _archive.Files)
                {
                    float progress = current++ / (float)total * 100;
                    App.UpdateProgress(this, (int)progress, $"Encrypting: {file.FullPath}");
                    selectedCrypto.Encrypt(file);
                }
            });
            await task;
            _archive.CryptoType = selectedCrypto.CryptoType;
            _ez2OnArchiveTabControl.Encryption = selectedCrypto.Name;
            _cmdKeyAdd.RaiseCanExecuteChanged();
            _cmdKeyDelete.RaiseCanExecuteChanged();
            _cmdAdd.RaiseCanExecuteChanged();
            App.ResetProgress(this);
            MessageBox.Show($"Added '{selectedCrypto.Name}' encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanAddKey()
        {
            return true;
            //   if (_archive == null)
            //   {
            //       return false;
            //   }
            //   if (_activeCrypto == null && _archive.CryptoType == Ez2OnArchiveCryptoType.AesCrypto)
            //   {
            //       return true;
            //   }
            //   if (_activeCrypto == null && _archive.CryptoType == Ez2OnArchiveCryptoType.None)
            //   {
            //       return true;
            //   }
            //   return false;
        }

        private async void KeyDelete()
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
                FileInfo selected = new SelectFileBuilder()
                    .Filter("Ez2On Archive Key file(*.key) | *.key")
                    .SelectSingle();
                if (selected == null)
                {
                    return;
                }
                byte[] key = Utils.ReadFile(selected.FullName);
                selectedICryptoPlugin.SetKey(key);
            }
            int total = _archive.Files.Count;
            int current = 0;
            var task = Task.Run(() =>
            {
                foreach (Ez2OnArchiveFile file in _archive.Files)
                {
                    float progress = current++ / (float)total * 100;
                    App.UpdateProgress(this, (int)progress, $"Decrypting: {file.FullPath}");
                    activeCrypto.Decrypt(file);
                }
            });
            await task;
            _archive.CryptoType = Ez2OnArchive.CRYPTO_TYPE_NONE;
            _ez2OnArchiveTabControl.Encryption = "None";
            _cmdKeyAdd.RaiseCanExecuteChanged();
            _cmdKeyDelete.RaiseCanExecuteChanged();
            _cmdAdd.RaiseCanExecuteChanged();
            App.ResetProgress(this);
            MessageBox.Show($"Removed '{activeCrypto.Name}' Encryption", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanDeleteKey()
        {
            return true;
            //   if (_archive == null)
            //   {
            //       return false;
            //   }
            //   if (_activeCrypto == null && _archive.CryptoType == Ez2OnArchiveCryptoType.EzCrypto)
            //   {
            //       return true;
            //   }
            //   if (_activeCrypto != null && _archive.CryptoType == Ez2OnArchiveCryptoType.AesCrypto)
            //   {
            //       return true;
            //   }
            //   return false;
        }

        private void KeyGenerate()
        {
            byte[] key = Utils.GenerateKey(16);
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
                _ez2OnArchiveTabControl.Items.Add(selectedFolder.Parent);
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
            _cmdExtract.RaiseCanExecuteChanged();
            _cmdDelete.RaiseCanExecuteChanged();
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

    }
}
