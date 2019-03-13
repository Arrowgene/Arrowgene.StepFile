using System;
using System.Collections.Generic;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Archive
{
    public class Ez2OnArchiveFolder
    {
        public Ez2OnArchiveFolder()
        {
            Folders = new List<Ez2OnArchiveFolder>();
            Files = new List<Ez2OnArchiveFile>();
            Name = "";
            FullPath = "";
            DirectoryPath = "";
        }

        public string Name { get; set; }
        public string FullPath { get; set; }
        public string DirectoryPath { get; set; }
        public List<Ez2OnArchiveFolder> Folders { get; }
        public List<Ez2OnArchiveFile> Files { get; }

        public void SetFullPath(string fullPath)
        {
            if (!string.IsNullOrEmpty(fullPath) && !fullPath.EndsWith("\\"))
            {
                fullPath += "\\";
            }
            FullPath = fullPath;
            string path = "";
            string[] folderNameParts = fullPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int length = folderNameParts.Length;
            for (int i = 0; i < length; i++)
            {
                string current = folderNameParts[i];
                if (i == length - 1)
                {
                    DirectoryPath = path;
                    Name = current;
                    return;
                }
                if (i == 0)
                {
                    path = current + '\\';
                }
                else
                {
                    path = path + current + '\\';
                }
            }
        }
    }
}
