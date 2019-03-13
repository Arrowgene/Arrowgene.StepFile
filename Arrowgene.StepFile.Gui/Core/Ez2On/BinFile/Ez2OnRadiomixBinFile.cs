using Arrowgene.Services.Buffers;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnRadiomixBinFile : Ez2OnBinFile<string>
    {
        public override string Header => "M_RADIOMIX";

        public override string ReadEntry(IBuffer buffer)
        {
            return "";
        }

        public override void WriteEntry(string str, IBuffer buffer)
        {
            WriteString(str, buffer);
        }
    }
}