using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;

namespace Arrowgene.StepFile.Gui.Control.LogTab
{
    public class LogTabController : TabController
    {
        protected LogTabControl LogTabControl { get; }

        public LogTabController() : base(new LogTabControl())
        {
            LogTabControl = TabUserControl as LogTabControl;
            LogProvider.GlobalLogWrite += LogProvider_GlobalLogWrite;

            Header = "Logs";

            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "LoggerIdentity", TextField = "LoggerIdentity" });
            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "Zone", TextField = "Zone" });
            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "Text", TextField = "Text" });
            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "LogLevel", TextField = "LogLevel" });
            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "DateTime", TextField = "DateTime" });
            LogTabControl.AddColumn(new DynamicGridViewColumn { Header = "Message", TextField = "Message" });

            LogTabControl.ClearCommand = new CommandHandler(Clear, true);
            LogTabControl.SaveCommand = new CommandHandler(Save, true);

        }
        private void Clear()
        {
            LogTabControl.ClearItems();
        }

        private void Save()
        {

        }

        private void LogProvider_GlobalLogWrite(object sender, LogWriteEventArgs e)
        {
            LogTabControl.Items.Add(new LogTabItem(e.Log));
        }
    }
}
