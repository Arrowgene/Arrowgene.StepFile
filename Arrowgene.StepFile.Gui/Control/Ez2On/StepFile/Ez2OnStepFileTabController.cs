using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using System.IO;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StepFile
{
    public class Ez2OnStepFileTabController : TabController
    {
        private Ez2OnStepFileTabControl _ez2OnStepFileTabControl;

        public Ez2OnStepFileTabController() : base(new Ez2OnStepFileTabControl())
        {
            _ez2OnStepFileTabControl = TabUserControl as Ez2OnStepFileTabControl;

            Header = "Ez2On StepFile";

            _ez2OnStepFileTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OnStepFileTabControl.SaveCommand = new CommandHandler(Save, true);
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
