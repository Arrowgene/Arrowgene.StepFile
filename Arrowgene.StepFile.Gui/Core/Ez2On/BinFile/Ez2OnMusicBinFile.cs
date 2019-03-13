using System;
using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.BinFile
{
    public class Ez2OnMusicBinFile : Ez2OnBinFile<Song>
    {
        public override string Header => "M_MUSIC";

        public override Song ReadEntry(IBuffer buffer)
        {
            Song song = new Song();
            song.Id = buffer.ReadInt32();

            buffer.ReadInt32();

            song.Name = ReadString(buffer);
            song.Category = GetSongCategory(ReadString(buffer));
            song.Duration = ReadString(buffer);
            song.Bpm = buffer.ReadInt32();
            song.FileName = ReadString(buffer);

            song.d1 = buffer.ReadInt32();

            song.d2 = buffer.ReadInt32();
            song.RubyEzExr = buffer.ReadInt32();
            song.d4 = buffer.ReadInt32();
            song.RubyEzNotes = buffer.ReadInt32();
            song.d6 = buffer.ReadInt32();

            song.d7 = buffer.ReadInt32();
            song.RubyNmExr = buffer.ReadInt32();
            song.d9 = buffer.ReadInt32();
            song.RubyNmNotes = buffer.ReadInt32();
            song.d11 = buffer.ReadInt32();

            song.d12 = buffer.ReadInt32();
            song.RubyHdExr = buffer.ReadInt32();
            song.d14 = buffer.ReadInt32();
            song.RubyHdNotes = buffer.ReadInt32();
            song.d16 = buffer.ReadInt32();

            song.d17 = buffer.ReadInt32();
            song.RubyShdExr = buffer.ReadInt32();
            song.d19 = buffer.ReadInt32();
            song.RubyShdNotes = buffer.ReadInt32();
            song.d21 = buffer.ReadInt32();

            song.d22 = buffer.ReadInt32();
            song.StreetEzExr = buffer.ReadInt32();
            song.d24 = buffer.ReadInt32();
            song.StreetEzNotes = buffer.ReadInt32();
            song.d26 = buffer.ReadInt32();

            song.d27 = buffer.ReadInt32();
            song.StreetNmExr = buffer.ReadInt32();
            song.d29 = buffer.ReadInt32();
            song.StreetNmNotes = buffer.ReadInt32();
            song.d31 = buffer.ReadInt32();

            song.d32 = buffer.ReadInt32();
            song.StreetHdExr = buffer.ReadInt32();
            song.d34 = buffer.ReadInt32();
            song.StreetHdNotes = buffer.ReadInt32();
            song.d36 = buffer.ReadInt32();

            song.d37 = buffer.ReadInt32();
            song.StreetShdExr = buffer.ReadInt32();
            song.d39 = buffer.ReadInt32();
            song.StreetShdNotes = buffer.ReadInt32();
            song.d41 = buffer.ReadInt32();

            song.d42 = buffer.ReadInt32();
            song.ClubEzExr = buffer.ReadInt32();
            song.d44 = buffer.ReadInt32();
            song.ClubEzNotes = buffer.ReadInt32();
            song.d46 = buffer.ReadInt32();

            song.d47 = buffer.ReadInt32();
            song.ClubNmExr = buffer.ReadInt32();
            song.d49 = buffer.ReadInt32();
            song.ClubNmNotes = buffer.ReadInt32();
            song.d51 = buffer.ReadInt32();

            song.d52 = buffer.ReadInt32();
            song.ClubHdExr = buffer.ReadInt32();
            song.d54 = buffer.ReadInt32();
            song.ClubHdNotes = buffer.ReadInt32();
            song.d56 = buffer.ReadInt32();

            song.d57 = buffer.ReadInt32();
            song.ClubShdExr = buffer.ReadInt32();
            song.d59 = buffer.ReadInt32();
            song.ClubShdNotes = buffer.ReadInt32();
            song.d61 = buffer.ReadInt32();

            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();
            
            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();

            return song;
        }

        public override void WriteEntry(Song song, IBuffer buffer)
        {
            buffer.WriteInt32(song.Id);
            WriteString(song.Name, buffer);
            WriteString(GetSongCategory(song.Category), buffer);
            WriteString(song.Duration, buffer);
            buffer.WriteInt32(song.Bpm);
            WriteString(song.FileName, buffer);
            buffer.WriteInt32(song.d1);
            buffer.WriteInt32(song.d2);
            buffer.WriteInt32(song.RubyEzExr);
            buffer.WriteInt32(song.d4);
            buffer.WriteInt32(song.RubyEzNotes);
            buffer.WriteInt32(song.d6);
            buffer.WriteInt32(song.d7);
            buffer.WriteInt32(song.RubyNmExr);
            buffer.WriteInt32(song.d9);
            buffer.WriteInt32(song.RubyNmNotes);
            buffer.WriteInt32(song.d11);
            buffer.WriteInt32(song.d12);
            buffer.WriteInt32(song.RubyHdExr);
            buffer.WriteInt32(song.d14);
            buffer.WriteInt32(song.RubyHdNotes);
            buffer.WriteInt32(song.d16);
            buffer.WriteInt32(song.d17);
            buffer.WriteInt32(song.RubyShdExr);
            buffer.WriteInt32(song.d19);
            buffer.WriteInt32(song.RubyShdNotes);
            buffer.WriteInt32(song.d21);
            buffer.WriteInt32(song.d22);
            buffer.WriteInt32(song.StreetEzExr);
            buffer.WriteInt32(song.d24);
            buffer.WriteInt32(song.StreetEzNotes);
            buffer.WriteInt32(song.d26);
            buffer.WriteInt32(song.d27);
            buffer.WriteInt32(song.StreetNmExr);
            buffer.WriteInt32(song.d29);
            buffer.WriteInt32(song.StreetNmNotes);
            buffer.WriteInt32(song.d31);
            buffer.WriteInt32(song.d32);
            buffer.WriteInt32(song.StreetHdExr);
            buffer.WriteInt32(song.d34);
            buffer.WriteInt32(song.ClubHdNotes);
            buffer.WriteInt32(song.d36);
            buffer.WriteInt32(song.d37);
            buffer.WriteInt32(song.StreetShdExr);
            buffer.WriteInt32(song.d39);
            buffer.WriteInt32(song.StreetShdNotes);
            buffer.WriteInt32(song.d41);
            buffer.WriteInt32(song.d42);
            buffer.WriteInt32(song.ClubEzExr);
            buffer.WriteInt32(song.d44);
            buffer.WriteInt32(song.ClubEzNotes);
            buffer.WriteInt32(song.d46);
            buffer.WriteInt32(song.d47);
            buffer.WriteInt32(song.ClubNmExr);
            buffer.WriteInt32(song.d49);
            buffer.WriteInt32(song.ClubNmNotes);
            buffer.WriteInt32(song.d51);
            buffer.WriteInt32(song.d52);
            buffer.WriteInt32(song.ClubHdExr);
            buffer.WriteInt32(song.d54);
            buffer.WriteInt32(song.ClubHdNotes);
            buffer.WriteInt32(song.d56);
            buffer.WriteInt32(song.d57);
            buffer.WriteInt32(song.ClubShdExr);
            buffer.WriteInt32(song.d59);
            buffer.WriteInt32(song.ClubShdNotes);
            buffer.WriteInt32(song.d61);
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

            return (SongCategoryType) categoryNum;
        }

        private string GetSongCategory(SongCategoryType category)
        {
            return ((int) category).ToString();
        }
    }
}