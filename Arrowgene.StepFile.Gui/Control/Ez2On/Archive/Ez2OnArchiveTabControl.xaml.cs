using Arrowgene.StepFile.Control.ArchiveTab;
using Arrowgene.StepFile.Core.Ez2On.Archive;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.Ez2On.Archive
{
    public partial class Ez2OnArchiveTabControl : ArchiveTabUserControl
    {
        private ICommand _keyAddCommand;
        private ICommand _keyDeleteCommand;
        private ICommand _keyGenerateCommand;

        private string _filePath;
        private Ez2OnArchiveType _archiveType;
        private string _encryption;
        private DateTime? _created;

        public ICommand KeyAddCommand { get { return _keyAddCommand; } set { _keyAddCommand = value; OnPropertyChanged("KeyAddCommand"); } }
        public ICommand KeyDeleteCommand { get { return _keyDeleteCommand; } set { _keyDeleteCommand = value; OnPropertyChanged("KeyDeleteCommand"); } }
        public ICommand KeyGenerateCommand { get { return _keyGenerateCommand; } set { _keyGenerateCommand = value; OnPropertyChanged("KeyGenerateCommand"); } }
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
