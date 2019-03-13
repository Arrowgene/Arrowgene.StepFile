using Arrowgene.StepFile.Control.Tab;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.Ez2On.DotBin
{
    public partial class Ez2OnDotBinTabControl : TabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;

        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }

        public Ez2OnDotBinTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
