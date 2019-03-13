using System;
using System.IO;
using System.Windows.Forms;

namespace Arrowgene.StepFile.Gui.Core
{
    public class SelectFolderBuilder
    {
        private FolderBrowserDialog _ofd;

        public SelectFolderBuilder()
        {
            _ofd = new FolderBrowserDialog();
        }

        public SelectFolderBuilder Description(string filter)
        {
            _ofd.Description = filter;
            return this;
        }

        public SelectFolderBuilder RootFolder(Environment.SpecialFolder rootFolder)
        {
            _ofd.RootFolder = rootFolder;
            return this;
        }

        public SelectFolderBuilder SelectedPath(string selectedPath)
        {
            _ofd.SelectedPath = selectedPath;
            return this;
        }

        public SelectFolderBuilder ShowNewFolderButton(bool showNewFolderButton)
        {
            _ofd.ShowNewFolderButton = showNewFolderButton;
            return this;
        }

        public DirectoryInfo Select()
        {
            DirectoryInfo directoryInfo;
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = _ofd.SelectedPath;
                directoryInfo = App.CreateDirectoryInfo(selectedPath);
            }
            else
            {
                directoryInfo = null;
            }
            return directoryInfo;
        }

    }
}
