using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Windows.Main
{
    public partial class MainWindow : Window, IMainWindow, INotifyPropertyChanged
    {
        private ICommand _ez2OnArchiveCommand;
        private ICommand _ez2OnStepFileCommand;
        private ICommand _logTabCommand;
        private ICommand _settingTabCommand;
        private int _progressBarValue;
        private string _progressBarText;

        Window IMainWindow.Window => this;
        TabControl IMainWindow.TabControl => tabControl;

        public string ProgressBarText { get { return _progressBarText; } set { _progressBarText = value; OnPropertyChanged("ProgressBarText"); } }
        public int ProgressBarValue { get { return _progressBarValue; } set { _progressBarValue = value; OnPropertyChanged("ProgressBarValue"); } }
        public ICommand Ez2OnArchiveCommand { get { return _ez2OnArchiveCommand; } set { _ez2OnArchiveCommand = value; OnPropertyChanged("Ez2OnArchiveCommand"); } }
        public ICommand Ez2OnStepFileCommand { get { return _ez2OnStepFileCommand; } set { _ez2OnStepFileCommand = value; OnPropertyChanged("Ez2OnStepFileCommand"); } }
        public ICommand LogTabCommand { get { return _logTabCommand; } set { _logTabCommand = value; OnPropertyChanged("LogTabCommand"); } }
        public ICommand SettingTabCommand { get { return _settingTabCommand; } set { _settingTabCommand = value; OnPropertyChanged("SettingTabCommand"); } }

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
