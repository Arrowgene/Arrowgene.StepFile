using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Windows.Main
{
    public partial class MainWindow : Window, IMainWindow, INotifyPropertyChanged
    {
        private ICommand _ez2OnArchiveCommand;
        private ICommand _ez2OnStepFileCommand;
        private ICommand _ez2OnDotBinCommand;
        private ICommand _ez2OnDotStrmCommand;
        private ICommand _logTabCommand;
        private ICommand _settingTabCommand;
        private ICommand _buildCommand;
        private int _progressBarValue;
        private string _progressBarText;

        Window IMainWindow.Window => this;
        TabControl IMainWindow.TabControl => tabControl;

        public string ProgressBarText { get { return _progressBarText; } set { _progressBarText = value; OnPropertyChanged("ProgressBarText"); } }
        public int ProgressBarValue { get { return _progressBarValue; } set { _progressBarValue = value; OnPropertyChanged("ProgressBarValue"); } }
        public ICommand Ez2OnArchiveCommand { get { return _ez2OnArchiveCommand; } set { _ez2OnArchiveCommand = value; OnPropertyChanged("Ez2OnArchiveCommand"); } }
        public ICommand Ez2OnDotBinCommand { get { return _ez2OnDotBinCommand; } set { _ez2OnDotBinCommand = value; OnPropertyChanged("Ez2OnDotBinCommand"); } }
        public ICommand Ez2OnDotStrmCommand { get { return _ez2OnDotStrmCommand; } set { _ez2OnDotStrmCommand = value; OnPropertyChanged("Ez2OnDotStrmCommand"); } }
        public ICommand Ez2OnStepFileCommand { get { return _ez2OnStepFileCommand; } set { _ez2OnStepFileCommand = value; OnPropertyChanged("Ez2OnStepFileCommand"); } }
        public ICommand LogTabCommand { get { return _logTabCommand; } set { _logTabCommand = value; OnPropertyChanged("LogTabCommand"); } }
        public ICommand SettingTabCommand { get { return _settingTabCommand; } set { _settingTabCommand = value; OnPropertyChanged("SettingTabCommand"); } }
        public ICommand BuildCommand { get { return _buildCommand; } set { _buildCommand = value; OnPropertyChanged("BuildCommand"); } }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
