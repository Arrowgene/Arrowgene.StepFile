using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace Arrowgene.StepFile.Gui.Control.ArchiveTab
{
    public abstract class ArchiveTabUserControl : TabUserControl
    {
        private DynamicGridViewColumnConfig _columnConfig;
        private ObservableCollection<DynamicGridViewItem> _items;
        private CollectionViewSource _viewSource;

        public abstract ListView ListViewItems { get; }
        public DynamicGridViewColumnConfig ColumnConfig { get { return _columnConfig; } set { _columnConfig = value; OnPropertyChanged("ColumnConfig"); } }
        public ICollectionView SourceCollection => _viewSource.View;
        public event FilterEventHandler Filter { add { _viewSource.Filter += value; } remove { _viewSource.Filter -= value; } }

        public ArchiveTabUserControl()
        {
            _columnConfig = new DynamicGridViewColumnConfig();
            _items = new ObservableCollection<DynamicGridViewItem>();
            _viewSource = new CollectionViewSource();
            _viewSource.Source = _items;
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

        public void RemoveItems(params DynamicGridViewItem[] items)
        {
            foreach (DynamicGridViewItem item in items)
            {
                _items.Remove(item);
            }
        }

        public DynamicGridViewItem GetItem(int index)
        {
            return _items[index];
        }

        public void SetItem(int index, DynamicGridViewItem item)
        {
            _items[index] = item;
        }

        public int IndexOf(DynamicGridViewItem item)
        {
            return _items.IndexOf(item);
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
