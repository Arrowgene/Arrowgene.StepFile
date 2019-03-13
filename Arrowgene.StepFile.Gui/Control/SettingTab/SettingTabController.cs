using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Gui.Control.Tab;

namespace Arrowgene.StepFile.Gui.Control.SettingTab
{
    public class SettingTabController : TabController
    {


        protected SettingTabControl SettingTabControl { get; }

        public SettingTabController() : base(new SettingTabControl())
        {
            SettingTabControl = TabUserControl as SettingTabControl;
            _logger = LogProvider<Logger>.GetLogger(this);
            Header = "Settings";
        }

    }
}
