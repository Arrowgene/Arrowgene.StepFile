using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnStrBinFile : Ez2OnBinFile<Ez2OnModelStr>
    {
        public override string Header => "M_GSTR";

        public override Ez2OnModelStr ReadEntry(IBuffer buffer)
        {
            Ez2OnModelStr str = new Ez2OnModelStr();
            str.Id = buffer.ReadInt32();
            str.Text = ReadString(buffer);
            return str;
        }

        public override void WriteEntry(Ez2OnModelStr str, IBuffer buffer)
        {
            buffer.WriteInt32(str.Id);
            WriteString(str.Text, buffer);
        }
    }
}