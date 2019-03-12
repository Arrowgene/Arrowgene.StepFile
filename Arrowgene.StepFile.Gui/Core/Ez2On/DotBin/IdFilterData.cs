using Arrowgene.Services.Buffers;

namespace Arrowgene.StepFile.Core.Asset.Ez2On.DotBin
{
    public class IdFilterData : BinFile<string>
    {
        public override string Header => "M_ID_FILTER";

        public override string ReadEntry(IBuffer buffer)
        {
            string str = ReadString(buffer);
            return str;
        }

        public override void WriteEntry(string str, IBuffer buffer)
        {
            WriteString(str, buffer);
        }
    }
}