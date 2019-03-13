using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;
using System;

namespace Arrowgene.StepFile.Gui.Control.LogTab
{
    public class LogTabItem : DynamicGridViewItem
    {

        private Log _log;

        public LogTabItem(Log log)
        {
            _log = log;
        }

        public string LoggerIdentity => _log.LoggerIdentity;
        public string Zone => _log.Zone;
        public string Text => _log.Text;
        public LogLevel LogLevel => _log.LogLevel;
        public DateTime DateTime => _log.DateTime;
        public string Message => _log.ToString();
    }
}
