using Arrowgene.Services.Buffers;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnIdFilterBinFile : Ez2OnBinFile<string>
    {
        public override string Header => "M_ID_FILTER";

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