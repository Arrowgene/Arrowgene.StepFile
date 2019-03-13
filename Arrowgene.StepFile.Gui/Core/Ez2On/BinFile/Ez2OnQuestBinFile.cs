using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnQuestBinFile : Ez2OnBinFile<Quest>
    {
        public override string Header => "M_QUEST";

        public override Quest ReadEntry(IBuffer buffer)
        {
            Quest quest = new Quest();
            quest.Id = buffer.ReadInt32();
            quest.a = buffer.ReadInt32();
            quest.b = buffer.ReadInt32();
            quest.c = buffer.ReadInt32();
            quest.d = buffer.ReadInt32();
            quest.Title = ReadString(buffer);
            quest.Mission = ReadString(buffer);
            quest.g = buffer.ReadInt32();
            quest.h = buffer.ReadInt32();
            quest.i = buffer.ReadInt32();
            quest.j = buffer.ReadInt32();
            quest.k = buffer.ReadInt32();
            quest.l = buffer.ReadInt32();
            quest.m = buffer.ReadInt32();
            quest.n = buffer.ReadInt32();
            quest.o = buffer.ReadInt32();
            quest.p = buffer.ReadInt32();
            quest.q = buffer.ReadInt32();
            quest.r = buffer.ReadInt32();
            quest.s = buffer.ReadInt32();
            quest.t = buffer.ReadInt32();
            quest.u = buffer.ReadInt32();
            quest.v = buffer.ReadInt32();
            quest.w = buffer.ReadInt32();
            quest.x = buffer.ReadInt32();
            quest.y = buffer.ReadInt32();
            quest.z = buffer.ReadInt32();
            quest.z1 = buffer.ReadInt32();
            quest.z2 = buffer.ReadInt32();
            quest.z3 = buffer.ReadInt32();
            quest.z4 = buffer.ReadInt32();
            quest.z5 = buffer.ReadInt32();
            quest.z6 = buffer.ReadInt32();
            quest.z7 = buffer.ReadInt32();
            quest.z8 = buffer.ReadInt32();
            quest.z9 = buffer.ReadInt32();
            quest.z10 = buffer.ReadInt32();
            quest.z11 = buffer.ReadInt32();
            return quest;
        }

        public override void WriteEntry(Quest quest, IBuffer buffer)
        {
            buffer.WriteInt32(quest.Id);
            buffer.WriteInt32(quest.Id);
            buffer.WriteInt32(quest.a);
            buffer.WriteInt32(quest.b);
            buffer.WriteInt32(quest.c);
            buffer.WriteInt32(quest.d);
            WriteString(quest.Title, buffer);
            WriteString(quest.Mission, buffer);
            buffer.WriteInt32(quest.g);
            buffer.WriteInt32(quest.h);
            buffer.WriteInt32(quest.i);
            buffer.WriteInt32(quest.j);
            buffer.WriteInt32(quest.k);
            buffer.WriteInt32(quest.l);
            buffer.WriteInt32(quest.m);
            buffer.WriteInt32(quest.n);
            buffer.WriteInt32(quest.o);
            buffer.WriteInt32(quest.p);
            buffer.WriteInt32(quest.q);
            buffer.WriteInt32(quest.r);
            buffer.WriteInt32(quest.s);
            buffer.WriteInt32(quest.t);
            buffer.WriteInt32(quest.u);
            buffer.WriteInt32(quest.v);
            buffer.WriteInt32(quest.w);
            buffer.WriteInt32(quest.x);
            buffer.WriteInt32(quest.y);
            buffer.WriteInt32(quest.z);
            buffer.WriteInt32(quest.z1);
            buffer.WriteInt32(quest.z2);
            buffer.WriteInt32(quest.z3);
            buffer.WriteInt32(quest.z4);
            buffer.WriteInt32(quest.z5);
            buffer.WriteInt32(quest.z6);
            buffer.WriteInt32(quest.z7);
            buffer.WriteInt32(quest.z8);
            buffer.WriteInt32(quest.z9);
            buffer.WriteInt32(quest.z10);
            buffer.WriteInt32(quest.z11);
        }
    }
}