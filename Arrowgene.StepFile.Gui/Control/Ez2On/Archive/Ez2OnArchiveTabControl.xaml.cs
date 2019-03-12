using Arrowgene.StepFile.Control.ArchiveTab;
using Arrowgene.StepFile.Core.Ez2On.Archive;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.Ez2On.Archive
{
    public partial class Ez2OnArchiveTabControl : ArchiveTabUserControl
    {
        private ICommand _openArchiveCommand;
        private ICommand _saveArchiveCommand;
        private ICommand _addFileCommand;
        private ICommand _addFolderCommand;
        private ICommand _extractSelectionCommand;
        private ICommand _deleteSelectionCommand;
        private ICommand _addEncryptionCommand;
        private ICommand _removeEncryptionCommand;
        private ICommand _generateKeyCommand;
        private ICommand _batchAddEncryptionCommand;
        private ICommand _batchRemoveEncryptionCommand;
        private string _filePath;
        private Ez2OnArchiveType _archiveType;
        private string _encryption;
        private DateTime? _created;

        public ICommand OpenArchiveCommand { get { return _openArchiveCommand; } set { _openArchiveCommand = value; OnPropertyChanged("OpenArchiveCommand"); } }
        public ICommand SaveArchiveCommand { get { return _saveArchiveCommand; } set { _saveArchiveCommand = value; OnPropertyChanged("SaveArchiveCommand"); } }
        public ICommand AddFileCommand { get { return _addFileCommand; } set { _addFileCommand = value; OnPropertyChanged("AddFileCommand"); } }
        public ICommand AddFolderCommand { get { return _addFolderCommand; } set { _addFolderCommand = value; OnPropertyChanged("AddFolderCommand"); } }
        public ICommand ExtractSelectionCommand { get { return _extractSelectionCommand; } set { _extractSelectionCommand = value; OnPropertyChanged("ExtractSelectionCommand"); } }
        public ICommand DeleteSelectionCommand { get { return _deleteSelectionCommand; } set { _deleteSelectionCommand = value; OnPropertyChanged("DeleteSelectionCommand"); } }
        public ICommand AddEncryptionCommand { get { return _addEncryptionCommand; } set { _addEncryptionCommand = value; OnPropertyChanged("AddEncryptionCommand"); } }
        public ICommand RemoveEncryptionCommand { get { return _removeEncryptionCommand; } set { _removeEncryptionCommand = value; OnPropertyChanged("RemoveEncryptionCommand"); } }
        public ICommand GenerateKeyCommand { get { return _generateKeyCommand; } set { _generateKeyCommand = value; OnPropertyChanged("GenerateKeyCommand"); } }
        public ICommand BatchAddEncryptionCommand { get { return _batchAddEncryptionCommand; } set { _batchAddEncryptionCommand = value; OnPropertyChanged("BatchAddEncryptionCommand"); } }
        public ICommand BatchRemoveEncryptionCommand { get { return _batchRemoveEncryptionCommand; } set { _batchRemoveEncryptionCommand = value; OnPropertyChanged("BatchRemoveEncryptionCommand"); } }
        public string FilePath { get { return _filePath; } set { _filePath = value; OnPropertyChanged("FilePath"); } }
        public Ez2OnArchiveType ArchiveType { get { return _archiveType; } set { _archiveType = value; OnPropertyChanged("ArchiveType"); } }
        public string Encryption { get { return _encryption; } set { _encryption = value; OnPropertyChanged("Encryption"); } }
        public DateTime? Created { get { return _created; } set { _created = value; OnPropertyChanged("Created"); } }

        public Ez2OnArchiveTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        public override ListView ListViewItems => listViewItems;
    }
}
