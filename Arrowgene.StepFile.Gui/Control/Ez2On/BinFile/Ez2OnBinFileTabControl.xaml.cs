using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public partial class Ez2OnBinFileTabControl : ArchiveTabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;

        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }
        
        public override ListView ListViewItems => listViewItems;

        public Ez2OnBinFileTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
