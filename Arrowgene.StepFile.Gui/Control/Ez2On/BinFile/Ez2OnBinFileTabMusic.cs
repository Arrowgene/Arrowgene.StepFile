using System.Windows.Controls;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabMusic : Ez2OnBinFileTabViewItem
    {
        private Ez2onModelMusic _modelMusic;

        public int Id { get; set; }
        public int E1 { get; set; }
        public string Name { get; set; }
        public SongCategoryType Category { get; set; }
        public string Duration { get; set; }
        public int Bpm { get; set; }
        public string FileName { get; set; }
        public int D1 { get; set; }
        public int D2 { get; set; }
        public int RubyEzExr { get; set; }
        public int D4 { get; set; }
        public int RubyEzNotes { get; set; }
        public int D6 { get; set; }
        public int D7 { get; set; }
        public int RubyNmExr { get; set; }
        public int D9 { get; set; }
        public int RubyNmNotes { get; set; }
        public int D11 { get; set; }
        public int D12 { get; set; }
        public int RubyHdExr { get; set; }
        public int D14 { get; set; }
        public int RubyHdNotes { get; set; }
        public int D16 { get; set; }
        public int D17 { get; set; }
        public int RubyShdExr { get; set; }
        public int D19 { get; set; }
        public int RubyShdNotes { get; set; }
        public int D21 { get; set; }
        public int D22 { get; set; }
        public int StreetEzExr { get; set; }
        public int D24 { get; set; }
        public int StreetEzNotes { get; set; }
        public int D26 { get; set; }
        public int D27 { get; set; }
        public int StreetNmExr { get; set; }
        public int D29 { get; set; }
        public int StreetNmNotes { get; set; }
        public int D31 { get; set; }
        public int D32 { get; set; }
        public int StreetHdExr { get; set; }
        public int D34 { get; set; }
        public int StreetHdNotes { get; set; }
        public int D36 { get; set; }
        public int D37 { get; set; }
        public int StreetShdExr { get; set; }
        public int D39 { get; set; }
        public int StreetShdNotes { get; set; }
        public int D41 { get; set; }
        public int D42 { get; set; }
        public int ClubEzExr { get; set; }
        public int D44 { get; set; }
        public int ClubEzNotes { get; set; }
        public int D46 { get; set; }
        public int D47 { get; set; }
        public int ClubNmExr { get; set; }
        public int D49 { get; set; }
        public int ClubNmNotes { get; set; }
        public int D51 { get; set; }
        public int D52 { get; set; }
        public int ClubHdExr { get; set; }
        public int D54 { get; set; }
        public int ClubHdNotes { get; set; }
        public int D56 { get; set; }
        public int D57 { get; set; }
        public int ClubShdExr { get; set; }
        public int D59 { get; set; }
        public int ClubShdNotes { get; set; }
        public int D61 { get; set; }
        public int E2 { get; set; }
        public int E3 { get; set; }
        public int E4 { get; set; }
        public int E5 { get; set; }
        public int E6 { get; set; }
        public int E7 { get; set; }
        public int E8 { get; set; }
        public int E9 { get; set; }
        public int E10 { get; set; }
        public int E11 { get; set; }
        public int E12 { get; set; }
        public int E13 { get; set; }
        public int E14 { get; set; }

        protected override object BindingSource => _modelMusic;

        public Ez2OnBinFileTabMusic(Ez2onModelMusic modelMusic)
        {
            _modelMusic = modelMusic;
            Id = _modelMusic.Id;
            E1 = _modelMusic.E1;
            Name = _modelMusic.Name;
            Category = _modelMusic.Category;
            Duration = _modelMusic.Duration;
            Bpm = _modelMusic.Bpm;
            FileName = _modelMusic.FileName;
            D1 = _modelMusic.D1;
            D2 = _modelMusic.D2;
            RubyEzExr = _modelMusic.RubyEzExr;
            D4 = _modelMusic.D4;
            RubyEzNotes = _modelMusic.RubyEzNotes;
            D6 = _modelMusic.D6;
            D7 = _modelMusic.D7;
            RubyNmExr = _modelMusic.RubyNmExr;
            D9 = _modelMusic.D9;
            RubyNmNotes = _modelMusic.RubyNmNotes;
            D11 = _modelMusic.D11;
            D12 = _modelMusic.D12;
            RubyHdExr = _modelMusic.RubyHdExr;
            D14 = _modelMusic.D14;
            RubyHdNotes = _modelMusic.RubyHdNotes;
            D16 = _modelMusic.D16;
            D17 = _modelMusic.D17;
            RubyShdExr = _modelMusic.RubyShdExr;
            D19 = _modelMusic.D19;
            RubyShdNotes = _modelMusic.RubyShdNotes;
            D21 = _modelMusic.D21;
            D22 = _modelMusic.D22;
            StreetEzExr = _modelMusic.StreetEzExr;
            D24 = _modelMusic.D24;
            StreetEzNotes = _modelMusic.StreetEzNotes;
            D26 = _modelMusic.D26;
            D27 = _modelMusic.D27;
            StreetNmExr = _modelMusic.StreetNmExr;
            D29 = _modelMusic.D29;
            StreetNmNotes = _modelMusic.StreetNmNotes;
            D31 = _modelMusic.D31;
            D32 = _modelMusic.D32;
            StreetHdExr = _modelMusic.StreetHdExr;
            D34 = _modelMusic.D34;
            StreetHdNotes = _modelMusic.StreetHdNotes;
            D36 = _modelMusic.D36;
            D37 = _modelMusic.D37;
            StreetShdExr = _modelMusic.StreetShdExr;
            D39 = _modelMusic.D39;
            StreetShdNotes = _modelMusic.StreetShdNotes;
            D41 = _modelMusic.D41;
            D42 = _modelMusic.D42;
            ClubEzExr = _modelMusic.ClubEzExr;
            D44 = _modelMusic.D44;
            ClubEzNotes = _modelMusic.ClubEzNotes;
            D46 = _modelMusic.D46;
            D47 = _modelMusic.D47;
            ClubNmExr = _modelMusic.ClubNmExr;
            D49 = _modelMusic.D49;
            ClubNmNotes = _modelMusic.ClubNmNotes;
            D51 = _modelMusic.D51;
            D52 = _modelMusic.D52;
            ClubHdExr = _modelMusic.ClubHdExr;
            D54 = _modelMusic.D54;
            ClubHdNotes = _modelMusic.ClubHdNotes;
            D56 = _modelMusic.D56;
            D57 = _modelMusic.D57;
            ClubShdExr = _modelMusic.ClubShdExr;
            D59 = _modelMusic.D59;
            ClubShdNotes = _modelMusic.ClubShdNotes;
            D61 = _modelMusic.D61;
            E2 = _modelMusic.E2;
            E3 = _modelMusic.E3;
            E4 = _modelMusic.E4;
            E5 = _modelMusic.E5;
            E6 = _modelMusic.E6;
            E7 = _modelMusic.E7;
            E8 = _modelMusic.E8;
            E9 = _modelMusic.E9;
            E10 = _modelMusic.E10;
            E11 = _modelMusic.E11;
            E12 = _modelMusic.E12;
            E13 = _modelMusic.E13;
            E14 = _modelMusic.E14;
        }
    }
}
