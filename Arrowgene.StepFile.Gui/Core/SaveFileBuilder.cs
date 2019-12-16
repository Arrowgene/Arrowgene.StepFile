using System.IO;
using System.Windows.Forms;

namespace Arrowgene.StepFile.Gui.Core
{
    public class SaveFileBuilder
    {
        private SaveFileDialog _ofd;

        public SaveFileBuilder()
        {
            _ofd = new SaveFileDialog();
        }

        public SaveFileBuilder AddExtension(bool addExtension)
        {
            _ofd.AddExtension = addExtension;
            return this;
        }

        public SaveFileBuilder AutoUpgradeEnabled(bool autoUpgradeEnabled)
        {
            _ofd.AutoUpgradeEnabled = autoUpgradeEnabled;
            return this;
        }

        public SaveFileBuilder CheckFileExists(bool checkFileExists)
        {
            _ofd.CheckFileExists = checkFileExists;
            return this;
        }

        public SaveFileBuilder CheckPathExists(bool checkPathExists)
        {
            _ofd.CheckPathExists = checkPathExists;
            return this;
        }

        public SaveFileBuilder CreatePrompt(bool createPrompt)
        {
            _ofd.CreatePrompt = createPrompt;
            return this;
        }

        public SaveFileBuilder DereferenceLinks(bool dereferenceLinks)
        {
            _ofd.DereferenceLinks = dereferenceLinks;
            return this;
        }

        public SaveFileBuilder FileName(string fileName)
        {
            _ofd.FileName = fileName;
            return this;
        }

        public SaveFileBuilder DefaultExt(string defaultExt)
        {
            _ofd.DefaultExt = defaultExt;
            return this;
        }

        public SaveFileBuilder Filter(string filter)
        {
            _ofd.Filter = filter;
            return this;
        }

        public SaveFileBuilder InitialDirectory(string initialDirectory)
        {
            _ofd.InitialDirectory = initialDirectory;
            return this;
        }

        public SaveFileBuilder OverwritePrompt(bool overwritePrompt)
        {
            _ofd.OverwritePrompt = overwritePrompt;
            return this;
        }

        public SaveFileBuilder RestoreDirectory(bool restoreDirectory)
        {
            _ofd.RestoreDirectory = restoreDirectory;
            return this;
        }

        public SaveFileBuilder ShowHelp(bool showHelp)
        {
            _ofd.ShowHelp = showHelp;
            return this;
        }

        public SaveFileBuilder SupportMultiDottedExtensions(bool supportMultiDottedExtensions)
        {
            _ofd.SupportMultiDottedExtensions = supportMultiDottedExtensions;
            return this;
        }

        public SaveFileBuilder Title(string title)
        {
            _ofd.Title = title;
            return this;
        }

        public SaveFileBuilder ValidateNames(bool validateNames)
        {
            _ofd.ValidateNames = validateNames;
            return this;
        }

        public FileInfo Select()
        {
            FileInfo fileInfo;
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = _ofd.FileName;
                fileInfo = App.CreateFileInfo(selectedFile);
            }
            else
            {
                fileInfo = null;
            }
            return fileInfo;
        }

    }
}
