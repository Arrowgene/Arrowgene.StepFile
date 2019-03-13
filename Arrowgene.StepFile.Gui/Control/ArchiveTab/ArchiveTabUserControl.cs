using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Gui.Control.ArchiveTab
{
    public abstract class ArchiveTabUserControl : TabUserControl
    {
        private DynamicGridViewColumnConfig _columnConfig;
        private ObservableCollection<DynamicGridViewItem> _items;

        public abstract ListView ListViewItems { get; }

        public DynamicGridViewColumnConfig ColumnConfig { get { return _columnConfig; } set { _columnConfig = value; OnPropertyChanged("ColumnConfig"); } }
        public ObservableCollection<DynamicGridViewItem> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ArchiveTabUserControl()
        {
            _columnConfig = new DynamicGridViewColumnConfig();
            _items = new ObservableCollection<DynamicGridViewItem>();
        }

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
        public void AddItems(params DynamicGridViewItem[] items)
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

        public void ClearColumns()
        {
            _columnConfig.Columns.Clear();
        }

    }
}
