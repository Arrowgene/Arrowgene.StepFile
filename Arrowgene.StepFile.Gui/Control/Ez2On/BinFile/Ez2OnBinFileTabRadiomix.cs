using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabRadiomix : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelRadiomix _modelRadiomix;

        protected override object BindingSource => _modelRadiomix;

        public Ez2OnBinFileTabRadiomix(Ez2OnModelRadiomix modelRadiomix)
        {
            _modelRadiomix = modelRadiomix;
        }
    }
}
