using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabMusic : Ez2OnBinFileTabViewItem
    {
        private Ez2onModelMusic _modelMusic;
        private int _id;
        private int _e1;
        private string _name;
        private SongCategoryType _category;
        private string _duration;
        private int _bpm;
        private string _fileName;
        private int _d1;
        private int _d2;
        private int _rubyEzExr;
        private int _d4;
        private int _rubyEzNotes;
        private int _d6;
        private int _d7;
        private int _rubyNmExr;
        private int _d9;
        private int _rubyNmNotes;
        private int _d11;
        private int _d12;
        private int _rubyHdExr;
        private int _d14;
        private int _rubyHdNotes;
        private int _d16;
        private int _d17;
        private int _rubyShdExr;
        private int _d19;
        private int _rubyShdNotes;
        private int _d21;
        private int _d22;
        private int _streetEzExr;
        private int _d24;
        private int _streetEzNotes;
        private int _d26;
        private int _d27;
        private int _streetNmExr;
        private int _d29;
        private int _streetNmNotes;
        private int _d31;
        private int _d32;
        private int _streetHdExr;
        private int _d34;
        private int _streetHdNotes;
        private int _d36;
        private int _d37;
        private int _streetShdExr;
        private int _d39;
        private int _streetShdNotes;
        private int _d41;
        private int _d42;
        private int _clubEzExr;
        private int _d44;
        private int _clubEzNotes;
        private int _d46;
        private int _d47;
        private int _clubNmExr;
        private int _d49;
        private int _clubNmNotes;
        private int _d51;
        private int _d52;
        private int _clubHdExr;
        private int _d54;
        private int _clubHdNotes;
        private int _d56;
        private int _d57;
        private int _clubShdExr;
        private int _d59;
        private int _clubShdNotes;
        private int _d61;
        private int _e2;
        private int _e3;
        private int _e4;
        private int _e5;
        private int _e6;
        private int _e7;
        private int _e8;
        private int _e9;
        private int _e10;
        private int _e11;
        private int _e12;
        private int _e13;
        private int _e14;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public int E1 { get { return _e1; } set { _e1 = value; OnPropertyChanged("E1"); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public SongCategoryType Category { get { return _category; } set { _category = value; OnPropertyChanged("Category"); } }
        public string Duration { get { return _duration; } set { _duration = value; OnPropertyChanged("Duration"); } }
        public int Bpm { get { return _bpm; } set { _bpm = value; OnPropertyChanged("Bpm"); } }
        public string FileName { get { return _fileName; } set { _fileName = value; OnPropertyChanged("FileName"); } }
        public int D1 { get { return _d1; } set { _d1 = value; OnPropertyChanged("D1"); } }
        public int D2 { get { return _d2; } set { _d2 = value; OnPropertyChanged("D2"); } }
        public int RubyEzExr { get { return _rubyEzExr; } set { _rubyEzExr = value; OnPropertyChanged("RubyEzExr"); } }
        public int D4 { get { return _d4; } set { _d4 = value; OnPropertyChanged("D4"); } }
        public int RubyEzNotes { get { return _rubyEzNotes; } set { _rubyEzNotes = value; OnPropertyChanged("RubyEzNotes"); } }
        public int D6 { get { return _d6; } set { _d6 = value; OnPropertyChanged("D6"); } }
        public int D7 { get { return _d7; } set { _d7 = value; OnPropertyChanged("D7"); } }
        public int RubyNmExr { get { return _rubyNmExr; } set { _rubyNmExr = value; OnPropertyChanged("RubyNmExr"); } }
        public int D9 { get { return _d9; } set { _d9 = value; OnPropertyChanged("D9"); } }
        public int RubyNmNotes { get { return _rubyNmNotes; } set { _rubyNmNotes = value; OnPropertyChanged("RubyNmNotes"); } }
        public int D11 { get { return _d11; } set { _d11 = value; OnPropertyChanged("D11"); } }
        public int D12 { get { return _d12; } set { _d12 = value; OnPropertyChanged("D12"); } }
        public int RubyHdExr { get { return _rubyHdExr; } set { _rubyHdExr = value; OnPropertyChanged("RubyHdExr"); } }
        public int D14 { get { return _d14; } set { _d14 = value; OnPropertyChanged("D14"); } }
        public int RubyHdNotes { get { return _rubyHdNotes; } set { _rubyHdNotes = value; OnPropertyChanged("RubyHdNotes"); } }
        public int D16 { get { return _d16; } set { _d16 = value; OnPropertyChanged("D16"); } }
        public int D17 { get { return _d17; } set { _d17 = value; OnPropertyChanged("D17"); } }
        public int RubyShdExr { get { return _rubyShdExr; } set { _rubyShdExr = value; OnPropertyChanged("RubyShdExr"); } }
        public int D19 { get { return _d19; } set { _d19 = value; OnPropertyChanged("D19"); } }
        public int RubyShdNotes { get { return _rubyShdNotes; } set { _rubyShdNotes = value; OnPropertyChanged("RubyShdNotes"); } }
        public int D21 { get { return _d21; } set { _d21 = value; OnPropertyChanged("D21"); } }
        public int D22 { get { return _d22; } set { _d22 = value; OnPropertyChanged("D22"); } }
        public int StreetEzExr { get { return _streetEzExr; } set { _streetEzExr = value; OnPropertyChanged("StreetEzExr"); } }
        public int D24 { get { return _d24; } set { _d24 = value; OnPropertyChanged("D24"); } }
        public int StreetEzNotes { get { return _streetEzNotes; } set { _streetEzNotes = value; OnPropertyChanged("StreetEzNotes"); } }
        public int D26 { get { return _d26; } set { _d26 = value; OnPropertyChanged("D26"); } }
        public int D27 { get { return _d27; } set { _d27 = value; OnPropertyChanged("D27"); } }
        public int StreetNmExr { get { return _streetNmExr; } set { _streetNmExr = value; OnPropertyChanged("StreetNmExr"); } }
        public int D29 { get { return _d29; } set { _d29 = value; OnPropertyChanged("D29"); } }
        public int StreetNmNotes { get { return _streetNmNotes; } set { _streetNmNotes = value; OnPropertyChanged("StreetNmNotes"); } }
        public int D31 { get { return _d31; } set { _d31 = value; OnPropertyChanged("D31"); } }
        public int D32 { get { return _d32; } set { _d32 = value; OnPropertyChanged("D32"); } }
        public int StreetHdExr { get { return _streetHdExr; } set { _streetHdExr = value; OnPropertyChanged("StreetHdExr"); } }
        public int D34 { get { return _d34; } set { _d34 = value; OnPropertyChanged("D34"); } }
        public int StreetHdNotes { get { return _streetHdNotes; } set { _streetHdNotes = value; OnPropertyChanged("StreetHdNotes"); } }
        public int D36 { get { return _d36; } set { _d36 = value; OnPropertyChanged("D36"); } }
        public int D37 { get { return _d37; } set { _d37 = value; OnPropertyChanged("D37"); } }
        public int StreetShdExr { get { return _streetShdExr; } set { _streetShdExr = value; OnPropertyChanged("StreetShdExr"); } }
        public int D39 { get { return _d39; } set { _d39 = value; OnPropertyChanged("D39"); } }
        public int StreetShdNotes { get { return _streetShdNotes; } set { _streetShdNotes = value; OnPropertyChanged("StreetShdNotes"); } }
        public int D41 { get { return _d41; } set { _d41 = value; OnPropertyChanged("D41"); } }
        public int D42 { get { return _d42; } set { _d42 = value; OnPropertyChanged("D42"); } }
        public int ClubEzExr { get { return _clubEzExr; } set { _clubEzExr = value; OnPropertyChanged("ClubEzExr"); } }
        public int D44 { get { return _d44; } set { _d44 = value; OnPropertyChanged("D44"); } }
        public int ClubEzNotes { get { return _clubEzNotes; } set { _clubEzNotes = value; OnPropertyChanged("ClubEzNotes"); } }
        public int D46 { get { return _d46; } set { _d46 = value; OnPropertyChanged("D46"); } }
        public int D47 { get { return _d47; } set { _d47 = value; OnPropertyChanged("D47"); } }
        public int ClubNmExr { get { return _clubNmExr; } set { _clubNmExr = value; OnPropertyChanged("ClubNmExr"); } }
        public int D49 { get { return _d49; } set { _d49 = value; OnPropertyChanged("D49"); } }
        public int ClubNmNotes { get { return _clubNmNotes; } set { _clubNmNotes = value; OnPropertyChanged("ClubNmNotes"); } }
        public int D51 { get { return _d51; } set { _d51 = value; OnPropertyChanged("D51"); } }
        public int D52 { get { return _d52; } set { _d52 = value; OnPropertyChanged("D52"); } }
        public int ClubHdExr { get { return _clubHdExr; } set { _clubHdExr = value; OnPropertyChanged("ClubHdExr"); } }
        public int D54 { get { return _d54; } set { _d54 = value; OnPropertyChanged("D54"); } }
        public int ClubHdNotes { get { return _clubHdNotes; } set { _clubHdNotes = value; OnPropertyChanged("ClubHdNotes"); } }
        public int D56 { get { return _d56; } set { _d56 = value; OnPropertyChanged("D56"); } }
        public int D57 { get { return _d57; } set { _d57 = value; OnPropertyChanged("D57"); } }
        public int ClubShdExr { get { return _clubShdExr; } set { _clubShdExr = value; OnPropertyChanged("ClubShdExr"); } }
        public int D59 { get { return _d59; } set { _d59 = value; OnPropertyChanged("D59"); } }
        public int ClubShdNotes { get { return _clubShdNotes; } set { _clubShdNotes = value; OnPropertyChanged("ClubShdNotes"); } }
        public int D61 { get { return _d61; } set { _d61 = value; OnPropertyChanged("D61"); } }
        public int E2 { get { return _e2; } set { _e2 = value; OnPropertyChanged("E2"); } }
        public int E3 { get { return _e3; } set { _e3 = value; OnPropertyChanged("E3"); } }
        public int E4 { get { return _e4; } set { _e4 = value; OnPropertyChanged("E4"); } }
        public int E5 { get { return _e5; } set { _e5 = value; OnPropertyChanged("E5"); } }
        public int E6 { get { return _e6; } set { _e6 = value; OnPropertyChanged("E6"); } }
        public int E7 { get { return _e7; } set { _e7 = value; OnPropertyChanged("E7"); } }
        public int E8 { get { return _e8; } set { _e8 = value; OnPropertyChanged("E8"); } }
        public int E9 { get { return _e9; } set { _e9 = value; OnPropertyChanged("E9"); } }
        public int E10 { get { return _e10; } set { _e10 = value; OnPropertyChanged("E10"); } }
        public int E11 { get { return _e11; } set { _e11 = value; OnPropertyChanged("E11"); } }
        public int E12 { get { return _e12; } set { _e12 = value; OnPropertyChanged("E12"); } }
        public int E13 { get { return _e13; } set { _e13 = value; OnPropertyChanged("E13"); } }
        public int E14 { get { return _e14; } set { _e14 = value; OnPropertyChanged("E14"); } }

        public Ez2OnBinFileTabMusic(Ez2onModelMusic modelMusic)
        {
            _modelMusic = modelMusic;
            Discard();
        }

        public override void Save()
        {
            _modelMusic.Id = Id;
            _modelMusic.E1 = E1;
            _modelMusic.Name = Name;
            _modelMusic.Category = Category;
            _modelMusic.Duration = Duration;
            _modelMusic.Bpm = Bpm;
            _modelMusic.FileName = FileName;
            _modelMusic.D1 = D1;
            _modelMusic.D2 = D2;
            _modelMusic.RubyEzExr = RubyEzExr;
            _modelMusic.D4 = D4;
            _modelMusic.RubyEzNotes = RubyEzNotes;
            _modelMusic.D6 = D6;
            _modelMusic.D7 = D7;
            _modelMusic.RubyNmExr = RubyNmExr;
            _modelMusic.D9 = D9;
            _modelMusic.RubyNmNotes = RubyNmNotes;
            _modelMusic.D11 = D11;
            _modelMusic.D12 = D12;
            _modelMusic.RubyHdExr = RubyHdExr;
            _modelMusic.D14 = D14;
            _modelMusic.RubyHdNotes = RubyHdNotes;
            _modelMusic.D16 = D16;
            _modelMusic.D17 = D17;
            _modelMusic.RubyShdExr = RubyShdExr;
            _modelMusic.D19 = D19;
            _modelMusic.RubyShdNotes = RubyShdNotes;
            _modelMusic.D21 = D21;
            _modelMusic.D22 = D22;
            _modelMusic.StreetEzExr = StreetEzExr;
            _modelMusic.D24 = D24;
            _modelMusic.StreetEzNotes = StreetEzNotes;
            _modelMusic.D26 = D26;
            _modelMusic.D27 = D27;
            _modelMusic.StreetNmExr = StreetNmExr;
            _modelMusic.D29 = D29;
            _modelMusic.StreetNmNotes = StreetNmNotes;
            _modelMusic.D31 = D31;
            _modelMusic.D32 = D32;
            _modelMusic.StreetHdExr = StreetHdExr;
            _modelMusic.D34 = D34;
            _modelMusic.StreetHdNotes = StreetHdNotes;
            _modelMusic.D36 = D36;
            _modelMusic.D37 = D37;
            _modelMusic.StreetShdExr = StreetShdExr;
            _modelMusic.D39 = D39;
            _modelMusic.StreetShdNotes = StreetShdNotes;
            _modelMusic.D41 = D41;
            _modelMusic.D42 = D42;
            _modelMusic.ClubEzExr = ClubEzExr;
            _modelMusic.D44 = D44;
            _modelMusic.ClubEzNotes = ClubEzNotes;
            _modelMusic.D46 = D46;
            _modelMusic.D47 = D47;
            _modelMusic.ClubNmExr = ClubNmExr;
            _modelMusic.D49 = D49;
            _modelMusic.ClubNmNotes = ClubNmNotes;
            _modelMusic.D51 = D51;
            _modelMusic.D52 = D52;
            _modelMusic.ClubHdExr = ClubHdExr;
            _modelMusic.D54 = D54;
            _modelMusic.ClubHdNotes = ClubHdNotes;
            _modelMusic.D56 = D56;
            _modelMusic.D57 = D57;
            _modelMusic.ClubShdExr = ClubShdExr;
            _modelMusic.D59 = D59;
            _modelMusic.ClubShdNotes = ClubShdNotes;
            _modelMusic.D61 = D61;
            _modelMusic.E2 = E2;
            _modelMusic.E3 = E3;
            _modelMusic.E4 = E4;
            _modelMusic.E5 = E5;
            _modelMusic.E6 = E6;
            _modelMusic.E7 = E7;
            _modelMusic.E8 = E8;
            _modelMusic.E9 = E9;
            _modelMusic.E10 = E10;
            _modelMusic.E11 = E11;
            _modelMusic.E12 = E12;
            _modelMusic.E13 = E13;
            _modelMusic.E14 = E14;
        }

        public override void Discard()
        {
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
