using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using Arrowgene.StepFile.Gui.Core.Ez2On.Archive;
using System.Collections.ObjectModel;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.Archive
{
    public class Ez2OnArchiveTabFolder : ArchiveTabItem
    {
        private Ez2OnArchiveFolder _folder;

        public Ez2OnArchiveFolder Folder => _folder;
        public string Name => _folder.Name;
        public string FullPath => _folder.FullPath;
        public string DirectoryPath => _folder.DirectoryPath;
        public ObservableCollection<Ez2OnArchiveTabFolder> Folders { get; }
        public ObservableCollection<Ez2OnArchiveTabFile> Files { get; }
        public Ez2OnArchiveTabFolder Parent { get; set; }
        public bool UpNavigation { get { return _upNavigation; } set { _upNavigation = value; ItemImageName = GetImage(); } }

        private bool _upNavigation;

        public Ez2OnArchiveTabFolder(Ez2OnArchiveFolder folder)
        {
            UpNavigation = false;
            _folder = folder;
            ItemImageName = GetImage();
            ItemTextName = _folder.Name;
            Files = new ObservableCollection<Ez2OnArchiveTabFile>();
            Folders = new ObservableCollection<Ez2OnArchiveTabFolder>();
            foreach (Ez2OnArchiveFile file in folder.Files)
            {
                Files.Add(new Ez2OnArchiveTabFile(file));
            }
            foreach (Ez2OnArchiveFolder subFolder in folder.Folders)
            {
                Ez2OnArchiveTabFolder tabFolder = new Ez2OnArchiveTabFolder(subFolder);
                tabFolder.Parent = this;
                Folders.Add(tabFolder);
            }
        }

        public void AddFile(Ez2OnArchiveTabFile file)
        {
            Files.Add(file);
            _folder.Files.Add(file.File);
        }

        public void RemoveFile(Ez2OnArchiveTabFile file)
        {
            Files.Remove(file);
            _folder.Files.Remove(file.File);
        }

        private string GetImage()
        {
            if (UpNavigation)
            {
                return "pack://application:,,,/icons/PastelSVG/folder-orange.png";
            }
            else
            {
                return "pack://application:,,,/icons/PastelSVG/folder.png";
            }
        }
    }
}
