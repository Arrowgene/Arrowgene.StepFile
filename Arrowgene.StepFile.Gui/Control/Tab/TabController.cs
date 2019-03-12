using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Core;
using System.ComponentModel;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.Tab
{

    /// <summary>
    /// Controls behaviour of a single tab.
    /// </summary>
    public abstract class TabController : INotifyPropertyChanged
    {

        private TabManager _tabManager;
        private string _header;

        protected Logger _logger;

        public string Header { get { return _header; } set { _header = value; OnPropertyChanged("Header"); } }
        public ICommand CloseTabCommand { get; }
        public TabUserControl TabUserControl { get; }

        public TabController(ITab iTab)
        {
            _logger = LogProvider<Logger>.GetLogger(this);
            TabUserControl = iTab.TabUserControl;
            CloseTabCommand = new CommandHandler(Close, true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Register(TabManager tabManager)
        {
            if (_tabManager != null)
            {
                return false;
            }
            _tabManager = tabManager;
            return true;
        }

        public void Close()
        {
            _tabManager.CloseTab(this);
        }
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
