using Arrowgene.StepFile.Control.Tab;
using Arrowgene.StepFile.Core.DynamicGridView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.LogTab
{
    public partial class LogTabControl : TabUserControl
    {
        public LogTabControl()
        {
            DataContext = this;
            InitializeComponent();
            _columnConfig = new DynamicGridViewColumnConfig();
            _items = new ObservableCollection<DynamicGridViewItem>();
        }

        public ListView ListViewItems => listViewItems;

        public DynamicGridViewColumnConfig ColumnConfig { get { return _columnConfig; } set { _columnConfig = value; OnPropertyChanged("ColumnConfig"); } }
        public ObservableCollection<DynamicGridViewItem> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }
        public ICommand ClearCommand { get { return _clearCommand; } set { _clearCommand = value; OnPropertyChanged("ClearCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }

        private DynamicGridViewColumnConfig _columnConfig;
        private ObservableCollection<DynamicGridViewItem> _items;
        private ICommand _clearCommand;
        private ICommand _saveCommand;

        public void AddColumn(DynamicGridViewColumn column)
        {
            _columnConfig.Columns.Add(column);
            OnPropertyChanged("ColumnConfig");
        }

        public void AddItemRange(IEnumerable<DynamicGridViewItem> items)
        {
            foreach (DynamicGridViewItem item in items)
            {
                _items.Add(item);
            }
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
