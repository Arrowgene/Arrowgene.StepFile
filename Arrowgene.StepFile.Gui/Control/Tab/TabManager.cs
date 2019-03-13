using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Gui.Control.Tab
{
    /// <summary>
    /// Manages opening / closing of tabs
    /// </summary>
    public class TabManager
    {
        private ObservableCollection<TabController> _tabs { get; set; }
        private TabControl _tabControl;

        public TabManager(TabControl tabControl)
        {
            _tabControl = tabControl;
            _tabs = new ObservableCollection<TabController>();
            tabControl.ItemsSource = _tabs;
        }

        public void OpenTab(TabController tabController)
        {
            if (tabController == null)
            {
                return;
            }
            if (!tabController.Register(this))
            {
                return;
            }
            _tabs.Add(tabController);
            _tabControl.SelectedItem = tabController;
        }

        public void CloseTab(TabController tabController)
        {
            _tabs.Remove(tabController);
        }
    }
}
