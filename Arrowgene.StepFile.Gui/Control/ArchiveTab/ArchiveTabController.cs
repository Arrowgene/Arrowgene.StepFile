using Arrowgene.StepFile.Gui.Control.Tab;

namespace Arrowgene.StepFile.Gui.Control.ArchiveTab
{
    public abstract class ArchiveTabController : TabController
    {
        private ArchiveTabUserControl _archiveTabUserControl { get; }

        public ArchiveTabController(ArchiveTabUserControl archiveTabUserControl) : base(archiveTabUserControl)
        {
            _archiveTabUserControl = archiveTabUserControl;
        }
    }
}
