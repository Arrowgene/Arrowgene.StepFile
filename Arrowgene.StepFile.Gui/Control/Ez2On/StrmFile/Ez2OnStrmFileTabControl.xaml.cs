using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StrmFile
{
    public partial class Ez2OnStrmFileTabControl : ArchiveTabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;
        private ICommand _editCommand;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _moveUpCommand;
        private ICommand _moveDownCommand;

        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }
        public ICommand EditCommand { get { return _editCommand; } set { _editCommand = value; OnPropertyChanged("EditCommand"); } }
        public ICommand AddCommand { get { return _addCommand; } set { _addCommand = value; OnPropertyChanged("AddCommand"); } }
        public ICommand DeleteCommand { get { return _deleteCommand; } set { _deleteCommand = value; OnPropertyChanged("DeleteCommand"); } }
        public ICommand MoveUpCommand { get { return _moveUpCommand; } set { _moveUpCommand = value; OnPropertyChanged("MoveUpCommand"); } }
        public ICommand MoveDownCommand { get { return _moveDownCommand; } set { _moveDownCommand = value; OnPropertyChanged("MoveDownCommand"); } }

        public override ListView ListViewItems => listViewItems;

        public Ez2OnStrmFileTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
