using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabRadiomix : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelRadiomix _modelRadiomix;

        public Ez2OnBinFileTabRadiomix(Ez2OnModelRadiomix modelRadiomix)
        {
            _modelRadiomix = modelRadiomix;
            Discard();
        }

        public override void Save()
        {
        }

        public override void Discard()
        {
        }
    }
}
