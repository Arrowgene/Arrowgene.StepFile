using Arrowgene.StepFile.Gui.Control.Ez2On.Archive;
using Arrowgene.StepFile.Gui.Control.Ez2On.BinFile;
using Arrowgene.StepFile.Gui.Control.Ez2On.StepFile;
using Arrowgene.StepFile.Gui.Control.LogTab;
using Arrowgene.StepFile.Gui.Control.SettingTab;
using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using System.IO;
using System.Windows;

namespace Arrowgene.StepFile.Gui.Windows.Main
{
    public class MainController
    {
        private TabManager _tabManager;

        public MainController(IMainWindow mainWindow)
        {
            mainWindow.Ez2OnArchiveCommand = new CommandHandler(OpenEz2OnArchiveTab, true);
            mainWindow.Ez2OnDotBinCommand = new CommandHandler(OpenDotBinTab, true);
            mainWindow.Ez2OnStepFileCommand = new CommandHandler(OpenEz2OnStepFileTab, true);
            mainWindow.LogTabCommand = new CommandHandler(OpenLogTab, true);
            mainWindow.SettingTabCommand = new CommandHandler(OpenSettingTab, true);
            _tabManager = new TabManager(mainWindow.TabControl);
            mainWindow.TabControl.AllowDrop = true;
            mainWindow.TabControl.Drop += TabControl_Drop;
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

        private void OpenDotBinTab()
        {
            _tabManager.OpenTab(new Ez2OnBinFileTabController());
        }

        private async void TabControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string drop in dropped)
                {
                    if (File.Exists(drop))
                    {
                        FileInfo file = App.CreateFileInfo(drop);
                        if (file == null)
                        {
                            continue;
                        }
                        string ext = file.Extension.ToLower();
                        switch (ext)
                        {
                            case ".dat":
                            case ".tro":
                                Ez2OnArchiveTabController archiveTab = new Ez2OnArchiveTabController();
                                _tabManager.OpenTab(archiveTab);
                                await archiveTab.Open(file);
                                break;
                            case ".bin":
                                Ez2OnBinFileTabController binFileTab = new Ez2OnBinFileTabController();
                                _tabManager.OpenTab(binFileTab);
                                binFileTab.Open(file);
                                break;
                        }
                    }
                    else if (Directory.Exists(drop))
                    {
                        DirectoryInfo directory = App.CreateDirectoryInfo(drop);
                    }
                }
            }
        }

    }
}
