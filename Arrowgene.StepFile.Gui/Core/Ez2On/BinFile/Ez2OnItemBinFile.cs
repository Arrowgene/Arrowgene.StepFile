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
            item.Q = buffer.ReadInt32();
            item.Type = (ItemType) buffer.ReadInt32();
            item.S = buffer.ReadInt32();
            item.T = buffer.ReadInt32();
            item.U = buffer.ReadInt32();
            item.Image = ReadString(buffer);
            item.A = buffer.ReadInt32();
            item.Name = ReadString(buffer);
            item.B = buffer.ReadInt32();
            item.Duration = buffer.ReadInt32();
            item.Coins = buffer.ReadInt32();
            item.Level = buffer.ReadInt32();
            item.ExpPlus = buffer.ReadInt32();
            item.CoinPlus = buffer.ReadInt32();
            item.HpPlus = buffer.ReadInt32();
            item.ResiliencePlus = buffer.ReadInt32();
            item.DefensePlus = buffer.ReadInt32();
            item.K = buffer.ReadInt32();
            item.L = buffer.ReadInt32();
            item.M = buffer.ReadInt32();
            item.N = buffer.ReadInt32();
            item.O = buffer.ReadInt32();
            item.V = buffer.ReadInt32();
            item.W = buffer.ReadInt32();
            item.X = buffer.ReadInt32();
            item.Effect = ReadString(buffer);
            return item;
        }

        public override void WriteEntry(Ez2OnModelItem item, IBuffer buffer)
        {
            buffer.WriteInt32(item.Id);
            buffer.WriteInt32(item.Q);
            buffer.WriteInt32((int) item.Type);
            buffer.WriteInt32(item.S);
            buffer.WriteInt32(item.T);
            buffer.WriteInt32(item.U);
            WriteString(item.Image, buffer);
            buffer.WriteInt32(item.A);
            WriteString(item.Name, buffer);
            buffer.WriteInt32(item.B);
            buffer.WriteInt32(item.Duration);
            buffer.WriteInt32(item.Coins);
            buffer.WriteInt32(item.Level);
            buffer.WriteInt32(item.ExpPlus);
            buffer.WriteInt32(item.CoinPlus);
            buffer.WriteInt32(item.HpPlus);
            buffer.WriteInt32(item.ResiliencePlus);
            buffer.WriteInt32(item.DefensePlus);
            buffer.WriteInt32(item.K);
            buffer.WriteInt32(item.L);
            buffer.WriteInt32(item.M);
            buffer.WriteInt32(item.N);
            buffer.WriteInt32(item.O);
            buffer.WriteInt32(item.V);
            buffer.WriteInt32(item.W);
            buffer.WriteInt32(item.X);
            WriteString(item.Effect, buffer);
        }
    }
}