using Arrowgene.StepFile.Control.Ez2On.Archive;
using Arrowgene.StepFile.Control.Ez2On.StepFile;
using Arrowgene.StepFile.Control.LogTab;
using Arrowgene.StepFile.Control.SettingTab;
using Arrowgene.StepFile.Control.Tab;
using Arrowgene.StepFile.Core;

namespace Arrowgene.StepFile.Windows.Main
{
    public class MainController
    {
        private TabManager _tabManager;

        public MainController(IMainWindow mainWindow)
        {
            mainWindow.Ez2OnArchiveCommand = new CommandHandler(OpenEz2OnArchiveTab, true);
            mainWindow.Ez2OnStepFileCommand = new CommandHandler(OpenEz2OnStepFileTab, true);
            mainWindow.LogTabCommand = new CommandHandler(OpenLogTab, true);
            mainWindow.SettingTabCommand = new CommandHandler(OpenSettingTab, true);
            _tabManager = new TabManager(mainWindow.TabControl);
        }

        private void OpenEz2OnArchiveTab()
        {
            _tabManager.OpenTab(new Ez2OnArchiveTabController());
        }
        private void OpenEz2OnStepFileTab()
        {
            _tabManager.OpenTab(new Ez2OnStepFileTabController());
        }

        private void OpenLogTab()
        {
            _tabManager.OpenTab(new LogTabController());
        }

        private void OpenSettingTab()
        {
            _tabManager.OpenTab(new SettingTabController());
        }

    }
}
