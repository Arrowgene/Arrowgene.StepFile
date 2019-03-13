using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using System.IO;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.DotBin
{
    public class Ez2OnDotBinTabController : TabController
    {
        private Ez2OnDotBinTabControl _ez2OndotBinTabControl;

        public Ez2OnDotBinTabController() : base(new Ez2OnDotBinTabControl())
        {
            _ez2OndotBinTabControl = TabUserControl as Ez2OnDotBinTabControl;

            Header = "Ez2On DotBin File";

            _ez2OndotBinTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OndotBinTabControl.SaveCommand = new CommandHandler(Save, true);
        }
        private void Open()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StepFile(*.bin) | *.bin")
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
