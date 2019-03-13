using Arrowgene.StepFile.Gui.Control.Tab;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StepFile
{
    public partial class Ez2OnStepFileTabControl : TabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;

        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }

        public Ez2OnStepFileTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
