using Arrowgene.StepFile.Gui.Control.ArchiveTab;
using Arrowgene.StepFile.Gui.Core.Ez2On.Archive;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.Archive
{
    public class Ez2OnArchiveTabFile : ArchiveTabItem
    {
        private Ez2OnArchiveFile _file;

        public Ez2OnArchiveTabFile(Ez2OnArchiveFile file)
        {
            _file = file;
            ItemImageName = GetImage();
            ItemTextName = _file.Name;
        }

        public Ez2OnArchiveFile File => _file;
        public string Name => _file.Name;
        public string Extension => _file.Extension;
        public string DirectoryPath => _file.DirectoryPath;
        public string FullPath => _file.FullPath;
        public int Offset => _file.Offset;
        public int Length => _file.Length;
        public bool Encrypted => _file.Encrypted;

        private string GetImage()
        {
            return "pack://application:,,,/icons/PastelSVG/page-white.png";
        }
    }
}
