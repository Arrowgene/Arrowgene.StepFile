using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public partial class Ez2OnBinFileTabControl : ArchiveTabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;
        private ICommand _editCommand;
        private ICommand _addCommand;
        private ICommand _deleteCommand;

        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }
        public ICommand EditCommand { get { return _editCommand; } set { _editCommand = value; OnPropertyChanged("EditCommand"); } }
        public ICommand AddCommand { get { return _addCommand; } set { _addCommand = value; OnPropertyChanged("AddCommand"); } }
        public ICommand DeleteCommand { get { return _deleteCommand; } set { _deleteCommand = value; OnPropertyChanged("DeleteCommand"); } }

        public override ListView ListViewItems => listViewItems;

        public Ez2OnBinFileTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
