using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace Arrowgene.StepFile.Core
{
    public class SelectFileBuilder
    {
        private OpenFileDialog _ofd;

        public SelectFileBuilder()
        {
            _ofd = new OpenFileDialog();
        }

        public SelectFileBuilder Filter(string filter)
        {
            _ofd.Filter = filter;
            return this;
        }

        public SelectFileBuilder Title(string title)
        {
            _ofd.Title = title;
            return this;
        }

        public SelectFileBuilder InitialDirectory(string initialDirectory)
        {
            _ofd.InitialDirectory = initialDirectory;
            return this;
        }

        public SelectFileBuilder CheckFileExists(bool checkFileExists)
        {
            _ofd.CheckFileExists = checkFileExists;
            return this;
        }

        public SelectFileBuilder CheckPathExists(bool checkPathExists)
        {
            _ofd.CheckPathExists = checkPathExists;
            return this;
        }

        public FileInfo SelectSingle()
        {
            FileInfo fileInfo;
            _ofd.Multiselect = false;
            if (_ofd.ShowDialog() == true)
            {
                string fileName = _ofd.FileName;
                fileInfo = App.CreateFileInfo(fileName);
            }
            else
            {
                fileInfo = null;
            }
            return fileInfo;
        }

        public List<FileInfo> SelectMulti()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            _ofd.Multiselect = true;
            if (_ofd.ShowDialog() == true)
            {
                string[] fileNames = _ofd.FileNames;
                foreach (string fileName in fileNames)
                {
                    FileInfo fileInfo = App.CreateFileInfo(fileName);
                    fileInfos.Add(fileInfo);
                }
            }
            return fileInfos;
        }
    }
}
