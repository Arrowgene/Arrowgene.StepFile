using System;
using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnMusicBinFile : Ez2OnBinFile<Ez2onModelMusic>
    {
        public override string Header => "M_MUSIC";

        public override Ez2onModelMusic ReadEntry(IBuffer buffer)
        {
            Ez2onModelMusic song = new Ez2onModelMusic();
            song.Id = buffer.ReadInt32();
            song.E1 = buffer.ReadInt32();
            song.Name = ReadString(buffer);
            song.Category = GetSongCategory(ReadString(buffer));
            song.Duration = ReadString(buffer);
            song.Bpm = buffer.ReadInt32();
            song.FileName = ReadString(buffer);
            song.D1 = buffer.ReadInt32();

            song.D2 = buffer.ReadInt32();
            song.RubyEzExr = buffer.ReadInt32();
            song.D4 = buffer.ReadInt32();
            song.RubyEzNotes = buffer.ReadInt32();
            song.D6 = buffer.ReadInt32();

            song.D7 = buffer.ReadInt32();
            song.RubyNmExr = buffer.ReadInt32();
            song.D9 = buffer.ReadInt32();
            song.RubyNmNotes = buffer.ReadInt32();
            song.D11 = buffer.ReadInt32();

            song.D12 = buffer.ReadInt32();
            song.RubyHdExr = buffer.ReadInt32();
            song.D14 = buffer.ReadInt32();
            song.RubyHdNotes = buffer.ReadInt32();
            song.D16 = buffer.ReadInt32();

            song.D17 = buffer.ReadInt32();
            song.RubyShdExr = buffer.ReadInt32();
            song.D19 = buffer.ReadInt32();
            song.RubyShdNotes = buffer.ReadInt32();
            song.D21 = buffer.ReadInt32();

            song.D22 = buffer.ReadInt32();
            song.StreetEzExr = buffer.ReadInt32();
            song.D24 = buffer.ReadInt32();
            song.StreetEzNotes = buffer.ReadInt32();
            song.D26 = buffer.ReadInt32();

            song.D27 = buffer.ReadInt32();
            song.StreetNmExr = buffer.ReadInt32();
            song.D29 = buffer.ReadInt32();
            song.StreetNmNotes = buffer.ReadInt32();
            song.D31 = buffer.ReadInt32();

            song.D32 = buffer.ReadInt32();
            song.StreetHdExr = buffer.ReadInt32();
            song.D34 = buffer.ReadInt32();
            song.StreetHdNotes = buffer.ReadInt32();
            song.D36 = buffer.ReadInt32();

            song.D37 = buffer.ReadInt32();
            song.StreetShdExr = buffer.ReadInt32();
            song.D39 = buffer.ReadInt32();
            song.StreetShdNotes = buffer.ReadInt32();
            song.D41 = buffer.ReadInt32();

            song.D42 = buffer.ReadInt32();
            song.ClubEzExr = buffer.ReadInt32();
            song.D44 = buffer.ReadInt32();
            song.ClubEzNotes = buffer.ReadInt32();
            song.D46 = buffer.ReadInt32();

            song.D47 = buffer.ReadInt32();
            song.ClubNmExr = buffer.ReadInt32();
            song.D49 = buffer.ReadInt32();
            song.ClubNmNotes = buffer.ReadInt32();
            song.D51 = buffer.ReadInt32();

            song.D52 = buffer.ReadInt32();
            song.ClubHdExr = buffer.ReadInt32();
            song.D54 = buffer.ReadInt32();
            song.ClubHdNotes = buffer.ReadInt32();
            song.D56 = buffer.ReadInt32();

            song.D57 = buffer.ReadInt32();
            song.ClubShdExr = buffer.ReadInt32();
            song.D59 = buffer.ReadInt32();
            song.ClubShdNotes = buffer.ReadInt32();
            song.D61 = buffer.ReadInt32();

            song.E2 = buffer.ReadInt32();
            song.E3 = buffer.ReadInt32();
            song.E4 = buffer.ReadInt32();
            song.E5 = buffer.ReadInt32();
            song.E6 = buffer.ReadInt32();
            song.E7 = buffer.ReadInt32();
            song.E8 = buffer.ReadInt32();
            song.E9 = buffer.ReadInt32();
            song.E10 = buffer.ReadInt32();
            song.E11 = buffer.ReadInt32();
            song.E12 = buffer.ReadInt32();
            song.E13 = buffer.ReadInt32();
            song.E14 = buffer.ReadInt32();
            return song;
        }

        public override void WriteEntry(Ez2onModelMusic song, IBuffer buffer)
        {
            buffer.WriteInt32(song.Id);
            buffer.WriteInt32(song.E1);
            WriteString(song.Name, buffer);
            WriteString(GetSongCategory(song.Category), buffer);
            WriteString(song.Duration, buffer);
            buffer.WriteInt32(song.Bpm);
            WriteString(song.FileName, buffer);
            buffer.WriteInt32(song.D1);
            buffer.WriteInt32(song.D2);
            buffer.WriteInt32(song.RubyEzExr);
            buffer.WriteInt32(song.D4);
            buffer.WriteInt32(song.RubyEzNotes);
            buffer.WriteInt32(song.D6);
            buffer.WriteInt32(song.D7);
            buffer.WriteInt32(song.RubyNmExr);
            buffer.WriteInt32(song.D9);
            buffer.WriteInt32(song.RubyNmNotes);
            buffer.WriteInt32(song.D11);
            buffer.WriteInt32(song.D12);
            buffer.WriteInt32(song.RubyHdExr);
            buffer.WriteInt32(song.D14);
            buffer.WriteInt32(song.RubyHdNotes);
            buffer.WriteInt32(song.D16);
            buffer.WriteInt32(song.D17);
            buffer.WriteInt32(song.RubyShdExr);
            buffer.WriteInt32(song.D19);
            buffer.WriteInt32(song.RubyShdNotes);
            buffer.WriteInt32(song.D21);
            buffer.WriteInt32(song.D22);
            buffer.WriteInt32(song.StreetEzExr);
            buffer.WriteInt32(song.D24);
            buffer.WriteInt32(song.StreetEzNotes);
            buffer.WriteInt32(song.D26);
            buffer.WriteInt32(song.D27);
            buffer.WriteInt32(song.StreetNmExr);
            buffer.WriteInt32(song.D29);
            buffer.WriteInt32(song.StreetNmNotes);
            buffer.WriteInt32(song.D31);
            buffer.WriteInt32(song.D32);
            buffer.WriteInt32(song.StreetHdExr);
            buffer.WriteInt32(song.D34);
            buffer.WriteInt32(song.ClubHdNotes);
            buffer.WriteInt32(song.D36);
            buffer.WriteInt32(song.D37);
            buffer.WriteInt32(song.StreetShdExr);
            buffer.WriteInt32(song.D39);
            buffer.WriteInt32(song.StreetShdNotes);
            buffer.WriteInt32(song.D41);
            buffer.WriteInt32(song.D42);
            buffer.WriteInt32(song.ClubEzExr);
            buffer.WriteInt32(song.D44);
            buffer.WriteInt32(song.ClubEzNotes);
            buffer.WriteInt32(song.D46);
            buffer.WriteInt32(song.D47);
            buffer.WriteInt32(song.ClubNmExr);
            buffer.WriteInt32(song.D49);
            buffer.WriteInt32(song.ClubNmNotes);
            buffer.WriteInt32(song.D51);
            buffer.WriteInt32(song.D52);
            buffer.WriteInt32(song.ClubHdExr);
            buffer.WriteInt32(song.D54);
            buffer.WriteInt32(song.ClubHdNotes);
            buffer.WriteInt32(song.D56);
            buffer.WriteInt32(song.D57);
            buffer.WriteInt32(song.ClubShdExr);
            buffer.WriteInt32(song.D59);
            buffer.WriteInt32(song.ClubShdNotes);
            buffer.WriteInt32(song.D61);
            buffer.WriteInt32(song.E2);
            buffer.WriteInt32(song.E3);
            buffer.WriteInt32(song.E4);
            buffer.WriteInt32(song.E5);
            buffer.WriteInt32(song.E6);
            buffer.WriteInt32(song.E7);
            buffer.WriteInt32(song.E8);
            buffer.WriteInt32(song.E9);
            buffer.WriteInt32(song.E10);
            buffer.WriteInt32(song.E11);
            buffer.WriteInt32(song.E12);
            buffer.WriteInt32(song.E13);
            buffer.WriteInt32(song.E14);
        }

        private SongCategoryType GetSongCategory(string category)
        {
            if (!int.TryParse(category, out int categoryNum))
            {
                return SongCategoryType.None;
            }

            if (!Enum.IsDefined(typeof(SongCategoryType), categoryNum))
            {
                return SongCategoryType.None;
            }

            return (SongCategoryType)categoryNum;
        }

        private string GetSongCategory(SongCategoryType category)
        {
            return ((int)category).ToString();
        }
    }
}