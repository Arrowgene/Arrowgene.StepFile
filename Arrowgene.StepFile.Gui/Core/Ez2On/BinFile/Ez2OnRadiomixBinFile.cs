using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnRadiomixBinFile : Ez2OnBinFile<Ez2OnModelRadiomix>
    {
        public override string Header => "M_RADIOMIX";

        public override Ez2OnModelRadiomix ReadEntry(IBuffer buffer)
        {
            return null;
        }

        public override void WriteEntry(Ez2OnModelRadiomix radioMix, IBuffer buffer)
        {

        }
    }
}