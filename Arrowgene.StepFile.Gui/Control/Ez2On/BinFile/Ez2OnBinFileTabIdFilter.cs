using System.Windows.Controls;
using System.Windows.Data;
using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabIdFilter : Ez2OnBinFileTabViewItem
    {
        private Ez2OnIdFilterBinFile _idFilterBinFile;
        private string _idFilter;
        private TextBox _filter;

        public string IdFilter { get { return _idFilter; } set { _idFilter = value; } }
        public TextBox Filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = Create("IdFilter");
                }
                return _filter;
            }
        }

        protected override object BindingSource => this;

        public Ez2OnBinFileTabIdFilter(string idFilter, Ez2OnIdFilterBinFile idFilterBinFile)
        {
            _idFilter = idFilter;
            _idFilterBinFile = idFilterBinFile;
        }
    }
}
