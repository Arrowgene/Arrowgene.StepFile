using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnItemBinFile : Ez2OnBinFile<Ez2OnModelItem>
    {
        public override string Header => "M_ITEM";

        public override Ez2OnModelItem ReadEntry(IBuffer buffer)
        {
            Ez2OnModelItem item = new Ez2OnModelItem();
            item.Id = buffer.ReadInt32();
            item.q = buffer.ReadInt32();
            item.Type = (ItemType) buffer.ReadInt32();
            item.s = buffer.ReadInt32();
            item.t = buffer.ReadInt32();
            item.u = buffer.ReadInt32();
            item.Image = ReadString(buffer);
            item.a = buffer.ReadInt32();
            item.Name = ReadString(buffer);
            item.b = buffer.ReadInt32();
            item.Duration = buffer.ReadInt32();
            item.Coins = buffer.ReadInt32();
            item.Level = buffer.ReadInt32();
            item.ExpPlus = buffer.ReadInt32();
            item.CoinPlus = buffer.ReadInt32();
            item.HpPlus = buffer.ReadInt32();
            item.ResiliencePlus = buffer.ReadInt32();
            item.DefensePlus = buffer.ReadInt32();
            item.k = buffer.ReadInt32();
            item.l = buffer.ReadInt32();
            item.m = buffer.ReadInt32();
            item.n = buffer.ReadInt32();
            item.o = buffer.ReadInt32();

            item.v = buffer.ReadInt32();
            item.w = buffer.ReadInt32();
            item.x = buffer.ReadInt32();

            item.Effect = ReadString(buffer);
            return item;
        }

        public override void WriteEntry(Ez2OnModelItem item, IBuffer buffer)
        {
            buffer.WriteInt32(item.Id);
            buffer.WriteInt32(item.q);
            buffer.WriteInt32((int) item.Type);
            buffer.WriteInt32(item.s);
            buffer.WriteInt32(item.t);
            buffer.WriteInt32(item.u);
            WriteString(item.Image, buffer);
            buffer.WriteInt32(item.a);
            WriteString(item.Name, buffer);
            buffer.WriteInt32(item.b);
            buffer.WriteInt32(item.Duration);
            buffer.WriteInt32(item.Coins);
            buffer.WriteInt32(item.Level);
            buffer.WriteInt32(item.ExpPlus);
            buffer.WriteInt32(item.CoinPlus);
            buffer.WriteInt32(item.HpPlus);
            buffer.WriteInt32(item.ResiliencePlus);
            buffer.WriteInt32(item.DefensePlus);
            buffer.WriteInt32(item.k);
            buffer.WriteInt32(item.l);
            buffer.WriteInt32(item.m);
            buffer.WriteInt32(item.n);
            buffer.WriteInt32(item.o);
            WriteString(item.Effect, buffer);
        }
    }
}