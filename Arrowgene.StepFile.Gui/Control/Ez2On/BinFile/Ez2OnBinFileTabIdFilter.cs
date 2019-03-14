using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabIdFilter : Ez2OnBinFileTabViewItem
    {
        private Ez2OnIdFilterBinFile _idFilterBinFile;

        public string IdFilter { get; set; }


        protected override object BindingSource => this;

        public Ez2OnBinFileTabIdFilter(string idFilter, Ez2OnIdFilterBinFile idFilterBinFile)
        {
            IdFilter = idFilter;
            _idFilterBinFile = idFilterBinFile;
        }
    }
}
