using Arrowgene.StepFile.Control.Tab;
using Arrowgene.StepFile.Core.DynamicGridView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Control.ArchiveTab
{
    public abstract class ArchiveTabUserControl : TabUserControl
    {
        private DynamicGridViewColumnConfig _columnConfig;
        private ObservableCollection<DynamicGridViewItem> _items;
        private ICommand _openCommand;
        private ICommand _saveCommand;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _extractCommand;

        public abstract ListView ListViewItems { get; }

        public DynamicGridViewColumnConfig ColumnConfig { get { return _columnConfig; } set { _columnConfig = value; OnPropertyChanged("ColumnConfig"); } }
        public ObservableCollection<DynamicGridViewItem> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }
        public ICommand OpenCommand { get { return _openCommand; } set { _openCommand = value; OnPropertyChanged("OpenCommand"); } }
        public ICommand SaveCommand { get { return _saveCommand; } set { _saveCommand = value; OnPropertyChanged("SaveCommand"); } }
        public ICommand AddCommand { get { return _addCommand; } set { _addCommand = value; OnPropertyChanged("AddCommand"); } }
        public ICommand DeleteCommand { get { return _deleteCommand; } set { _deleteCommand = value; OnPropertyChanged("DeleteCommand"); } }
        public ICommand ExtractCommand { get { return _extractCommand; } set { _extractCommand = value; OnPropertyChanged("ExtractCommand"); } }

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

        public void ClearItems()
        {
            _items.Clear();
        }

    }
}
