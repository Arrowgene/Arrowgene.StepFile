using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Control.Tab;
using Arrowgene.StepFile.Core;
using System.IO;

namespace Arrowgene.StepFile.Control.Ez2On.DotBin
{
    public class Ez2OnDotBinTabController : TabController
    {
        private Ez2OnDotBinTabControl _ez2OndotBinTabControl;

        public Ez2OnDotBinTabController() : base(new Ez2OnDotBinTabControl())
        {
            _ez2OndotBinTabControl = TabUserControl as Ez2OnDotBinTabControl;

            Header = "Ez2On StepFile";

            _ez2OndotBinTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OndotBinTabControl.SaveCommand = new CommandHandler(Save, true);
        }
        private void Open()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StepFile(*.ptn) | *.ptn")
                .SelectSingle();
            if (selected == null)
            {
                return;
            }
        }

        private void Save()
        {

        }
    }
}
