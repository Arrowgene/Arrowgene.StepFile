using Arrowgene.StepFile.Gui.Control.Tab;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StepFile
{
    public partial class Ez2OnStepFileTabControl : TabUserControl
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;
        private ICommand _pt2ezCommand;
        private ICommand _pt2EzFolderCommand;
        
        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }
        public ICommand Pt2EzCommand { get { return _pt2ezCommand; } set { _pt2ezCommand = value; OnPropertyChanged("Pt2EzCommand"); } }
        public ICommand Pt2EzFolderCommand { get { return _pt2EzFolderCommand; } set { _pt2EzFolderCommand = value; OnPropertyChanged("Pt2EzFolderCommand"); } }
        
        public Ez2OnStepFileTabControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
