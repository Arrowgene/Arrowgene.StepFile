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
        public int Unknown { get { return _e1; } set { _e1 = value; OnPropertyChanged("Unknown"); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public SongCategoryType Category { get { return _category; } set { _category = value; OnPropertyChanged("Category"); } }
        public string Duration { get { return _duration; } set { _duration = value; OnPropertyChanged("Duration"); } }
        public int Bpm { get { return _bpm; } set { _bpm = value; OnPropertyChanged("Bpm"); } }
        public string FileName { get { return _fileName; } set { _fileName = value; OnPropertyChanged("FileName"); } }
        public int New { get { return _d1; } set { _d1 = value; OnPropertyChanged("New"); } }
        public int LicensePrice { get { return _d2; } set { _d2 = value; OnPropertyChanged("LicensePrice"); } }

        public int RubyEzActivation { get { return _d4; } set { _d4 = value; OnPropertyChanged("RubyEzActivation"); } }
        public int RubyEzExr { get { return _rubyEzExr; } set { _rubyEzExr = value; OnPropertyChanged("RubyEzExr"); } }
        public int RubyEzUnknown { get { return _d6; } set { _d6 = value; OnPropertyChanged("RubyEzUnknown"); } }
        public int RubyEzNotes { get { return _rubyEzNotes; } set { _rubyEzNotes = value; OnPropertyChanged("RubyEzNotes"); } }
        public int RubyEzUnlock { get { return _d7; } set { _d7 = value; OnPropertyChanged("RubyEzUnlock"); } }
        public int RubyEzDjPoint { get { return _d9; } set { _d9 = value; OnPropertyChanged("RubyEzDjPoint"); } }

        public int RubyNmActivation { get { return _d11; } set { _d11 = value; OnPropertyChanged("RubyNmActivation"); } }
        public int RubyNmExr { get { return _rubyNmExr; } set { _rubyNmExr = value; OnPropertyChanged("RubyNmExr"); } }
        public int RubyNmUnknown { get { return _d12; } set { _d12 = value; OnPropertyChanged("RubyNmUnknown"); } }
        public int RubyNmNotes { get { return _rubyNmNotes; } set { _rubyNmNotes = value; OnPropertyChanged("RubyNmNotes"); } }
        public int RubyNmUnlock { get { return _d14; } set { _d14 = value; OnPropertyChanged("RubyNmUnlock"); } }
        public int RubyNmDjPoint { get { return _d16; } set { _d16 = value; OnPropertyChanged("RubyNmDjPoint"); } }

        public int RubyHdActivation { get { return _d17; } set { _d17 = value; OnPropertyChanged("RubyHdActivation"); } }
        public int RubyHdExr { get { return _rubyHdExr; } set { _rubyHdExr = value; OnPropertyChanged("RubyHdExr"); } }
        public int RubyHdUnknown { get { return _d19; } set { _d19 = value; OnPropertyChanged("RubyHdUnknown"); } }
        public int RubyHdNotes { get { return _rubyHdNotes; } set { _rubyHdNotes = value; OnPropertyChanged("RubyHdNotes"); } }
        public int RubyHdUnlock { get { return _d21; } set { _d21 = value; OnPropertyChanged("RubyHdUnlock"); } }
        public int RubyHdDjPoint { get { return _d22; } set { _d22 = value; OnPropertyChanged("RubyHdDjPoint"); } }


        public int RubyShdActivation { get { return _e3; } set { _e3 = value; OnPropertyChanged("RubyShdActivation"); } }
        public int RubyShdExr { get { return _rubyShdExr; } set { _rubyShdExr = value; OnPropertyChanged("RubyShdExr"); } }
        public int RubyShdUnknown { get { return _e4; } set { _e4 = value; OnPropertyChanged("RubyShdUnknown"); } }
        public int RubyShdNotes { get { return _rubyShdNotes; } set { _rubyShdNotes = value; OnPropertyChanged("RubyShdNotes"); } }
        public int RubyShdUnlock { get { return _e5; } set { _e5 = value; OnPropertyChanged("RubyShdUnlock"); } }
        public int RubyShdDjPoint { get { return _e6; } set { _e6 = value; OnPropertyChanged("RubyShdDjPoint"); } }

        public int StreetEzActivation { get { return _e7; } set { _e7 = value; OnPropertyChanged("StreetEzActivation"); } }
        public int StreetEzExr { get { return _streetEzExr; } set { _streetEzExr = value; OnPropertyChanged("StreetEzExr"); } }
        public int StreetEzUnknown { get { return _e8; } set { _e8 = value; OnPropertyChanged("StreetEzUnknown"); } }
        public int StreetEzUnlock { get { return _d24; } set { _d24 = value; OnPropertyChanged("StreetEzUnlock"); } }
        public int StreetEzNotes { get { return _streetEzNotes; } set { _streetEzNotes = value; OnPropertyChanged("StreetEzNotes"); } }
        public int StreetEzDjPoint { get { return _d26; } set { _d26 = value; OnPropertyChanged("StreetEzDjPoint"); } }

        public int SteetNmActivation { get { return _d27; } set { _d27 = value; OnPropertyChanged("SteetNmActivation"); } }
        public int StreetNmExr { get { return _streetNmExr; } set { _streetNmExr = value; OnPropertyChanged("StreetNmExr"); } }
        public int StreetNmUnknown { get { return _d29; } set { _d29 = value; OnPropertyChanged("StreetNmUnknown"); } }
        public int StreetNmNotes { get { return _streetNmNotes; } set { _streetNmNotes = value; OnPropertyChanged("StreetNmNotes"); } }
        public int StreetNmUnlock { get { return _d31; } set { _d31 = value; OnPropertyChanged("StreetNmUnlock"); } }
        public int StreetNmDjPoint { get { return _d32; } set { _d32 = value; OnPropertyChanged("StreetNmDjPoint"); } }

        public int StreetHdActivation { get { return _e9; } set { _e9 = value; OnPropertyChanged("StreetHdActivation"); } }
        public int StreetHdExr { get { return _streetHdExr; } set { _streetHdExr = value; OnPropertyChanged("StreetHdExr"); } }
        public int StreetHdUnknown { get { return _d34; } set { _d34 = value; OnPropertyChanged("StreetHdUnknown"); } }
        public int StreetHdNotes { get { return _streetHdNotes; } set { _streetHdNotes = value; OnPropertyChanged("StreetHdNotes"); } }
        public int StreetHdUnlock { get { return _d36; } set { _d36 = value; OnPropertyChanged("StreetHdUnlock"); } }
        public int StreetHdDjPoint { get { return _d37; } set { _d37 = value; OnPropertyChanged("StreetHdDjPoint"); } }

        public int StreetShdActivation { get { return _e10; } set { _e10 = value; OnPropertyChanged("StreetShdActivation"); } }
        public int StreetShdExr { get { return _streetShdExr; } set { _streetShdExr = value; OnPropertyChanged("StreetShdExr"); } }
        public int StreetShdUnknown { get { return _d39; } set { _d39 = value; OnPropertyChanged("StreetShdUnknown"); } }
        public int StreetShdNotes { get { return _streetShdNotes; } set { _streetShdNotes = value; OnPropertyChanged("StreetShdNotes"); } }
        public int StreetShdUnlock { get { return _d41; } set { _d41 = value; OnPropertyChanged("StreetShdUnlock"); } }
        public int StreetShdDjPoint { get { return _d42; } set { _d42 = value; OnPropertyChanged("StreetShdDjPoint"); } }

        public int ClubEzActivation { get { return _e11; } set { _e11 = value; OnPropertyChanged("ClubEzActivation"); } }
        public int ClubEzExr { get { return _clubEzExr; } set { _clubEzExr = value; OnPropertyChanged("ClubEzExr"); } }
        public int ClubEzUnknown { get { return _d44; } set { _d44 = value; OnPropertyChanged("ClubEzUnknown"); } }
        public int ClubEzNotes { get { return _clubEzNotes; } set { _clubEzNotes = value; OnPropertyChanged("ClubEzNotes"); } }
        public int ClubEzUnlock { get { return _d46; } set { _d46 = value; OnPropertyChanged("ClubEzUnlock"); } }
        public int ClubEzDjPoint { get { return _d47; } set { _d47 = value; OnPropertyChanged("ClubEzDjPoint"); } }

        public int ClubNmActivation { get { return _e12; } set { _e12 = value; OnPropertyChanged("ClubNmActivation"); } }
        public int ClubNmExr { get { return _clubNmExr; } set { _clubNmExr = value; OnPropertyChanged("ClubNmExr"); } }
        public int ClubNmUnknown { get { return _d49; } set { _d49 = value; OnPropertyChanged("ClubNmUnknown"); } }
        public int ClubNmNotes { get { return _clubNmNotes; } set { _clubNmNotes = value; OnPropertyChanged("ClubNmNotes"); } }
        public int ClubNmUnlock { get { return _d51; } set { _d51 = value; OnPropertyChanged("ClubNmUnlock"); } }
        public int ClubNmDjPoint { get { return _d52; } set { _d52 = value; OnPropertyChanged("ClubNmDjPoint"); } }

        public int ClubHdActivation { get { return _e13; } set { _e13 = value; OnPropertyChanged("ClubHdActivation"); } }
        public int ClubHdExr { get { return _clubHdExr; } set { _clubHdExr = value; OnPropertyChanged("ClubHdExr"); } }
        public int ClubHdUnknown { get { return _d54; } set { _d54 = value; OnPropertyChanged("ClubHdUnknown"); } }
        public int ClubHdNotes { get { return _clubHdNotes; } set { _clubHdNotes = value; OnPropertyChanged("ClubHdNotes"); } }
        public int ClubHdUnlock { get { return _d56; } set { _d56 = value; OnPropertyChanged("ClubHdUnlock"); } }
        public int ClubHdDjPoint { get { return _d57; } set { _d57 = value; OnPropertyChanged("ClubHdDjPoint"); } }

        public int ClubShdActivation { get { return _e14; } set { _e14 = value; OnPropertyChanged("ClubShdActivation"); } }
        public int ClubShdExr { get { return _clubShdExr; } set { _clubShdExr = value; OnPropertyChanged("ClubShdExr"); } }
        public int ClubShdUnknown { get { return _d59; } set { _d59 = value; OnPropertyChanged("ClubShdUnknown"); } }
        public int ClubShdNotes { get { return _clubShdNotes; } set { _clubShdNotes = value; OnPropertyChanged("ClubShdNotes"); } }
        public int ClubShdUnlock { get { return _d61; } set { _d61 = value; OnPropertyChanged("ClubShdUnlock"); } }
        public int ClubShdDjPoint { get { return _e2; } set { _e2 = value; OnPropertyChanged("ClubShdDjPoint"); } }

        public Ez2OnBinFileTabMusic(Ez2onModelMusic modelMusic)
        {
            _modelMusic = modelMusic;
            Discard();
        }

        public override void Save()
        {
            _modelMusic.Id = Id;
            _modelMusic.Unknown = Unknown;
            _modelMusic.Name = Name;
            _modelMusic.Category = Category;
            _modelMusic.Duration = Duration;
            _modelMusic.Bpm = Bpm;
            _modelMusic.FileName = FileName;
            _modelMusic.New = New;
            _modelMusic.LicensePrice = LicensePrice;
            _modelMusic.RubyEzExr = RubyEzExr;
            _modelMusic.RubyEzActivation = RubyEzActivation;
            _modelMusic.RubyEzNotes = RubyEzNotes;
            _modelMusic.RubyEzUnknown = RubyEzUnknown;
            _modelMusic.RubyEzUnlock = RubyEzUnlock;
            _modelMusic.RubyNmExr = RubyNmExr;
            _modelMusic.RubyEzDjPoint = RubyEzDjPoint;
            _modelMusic.RubyNmNotes = RubyNmNotes;
            _modelMusic.RubyNmActivation = RubyNmActivation;
            _modelMusic.RubyNmUnknown = RubyNmUnknown;
            _modelMusic.RubyHdExr = RubyHdExr;
            _modelMusic.RubyNmUnlock = RubyNmUnlock;
            _modelMusic.RubyHdNotes = RubyHdNotes;
            _modelMusic.RubyNmDjPoint = RubyNmDjPoint;
            _modelMusic.RubyHdActivation = RubyHdActivation;
            _modelMusic.RubyShdExr = RubyShdExr;
            _modelMusic.RubyHdUnknown = RubyHdUnknown;
            _modelMusic.RubyShdNotes = RubyShdNotes;
            _modelMusic.RubyHdUnlock = RubyHdUnlock;
            _modelMusic.RubyHdDjPoint = RubyHdDjPoint;
            _modelMusic.StreetEzExr = StreetEzExr;
            _modelMusic.StreetEzUnlock = StreetEzUnlock;
            _modelMusic.StreetEzNotes = StreetEzNotes;
            _modelMusic.StreetEzDjPoint = StreetEzDjPoint;
            _modelMusic.SteetNmActivation = SteetNmActivation;
            _modelMusic.StreetNmExr = StreetNmExr;
            _modelMusic.StreetNmUnknown = StreetNmUnknown;
            _modelMusic.StreetNmNotes = StreetNmNotes;
            _modelMusic.StreetNmUnlock = StreetNmUnlock;
            _modelMusic.StreetNmDjPoint = StreetNmDjPoint;
            _modelMusic.StreetHdExr = StreetHdExr;
            _modelMusic.StreetHdUnknown = StreetHdUnknown;
            _modelMusic.StreetHdNotes = StreetHdNotes;
            _modelMusic.StreetHdUnlock = StreetHdUnlock;
            _modelMusic.StreetHdDjPoint = StreetHdDjPoint;
            _modelMusic.StreetShdExr = StreetShdExr;
            _modelMusic.StreetShdUnknown = StreetShdUnknown;
            _modelMusic.StreetShdNotes = StreetShdNotes;
            _modelMusic.StreetShdUnlock = StreetShdUnlock;
            _modelMusic.StreetShdDjPoint = StreetShdDjPoint;
            _modelMusic.ClubEzExr = ClubEzExr;
            _modelMusic.ClubEzUnknown = ClubEzUnknown;
            _modelMusic.ClubEzNotes = ClubEzNotes;
            _modelMusic.ClubEzUnlock = ClubEzUnlock;
            _modelMusic.ClubEzDjPoint = ClubEzDjPoint;
            _modelMusic.ClubNmExr = ClubNmExr;
            _modelMusic.ClubNmUnknown = ClubNmUnknown;
            _modelMusic.ClubNmNotes = ClubNmNotes;
            _modelMusic.ClubNmUnlock = ClubNmUnlock;
            _modelMusic.ClubNmDjPoint = ClubNmDjPoint;
            _modelMusic.ClubHdExr = ClubHdExr;
            _modelMusic.ClubHdUnknown = ClubHdUnknown;
            _modelMusic.ClubHdNotes = ClubHdNotes;
            _modelMusic.ClubHdUnlock = ClubHdUnlock;
            _modelMusic.ClubHdDjPoint = ClubHdDjPoint;
            _modelMusic.ClubShdExr = ClubShdExr;
            _modelMusic.ClubShdUnknown = ClubShdUnknown;
            _modelMusic.ClubShdNotes = ClubShdNotes;
            _modelMusic.ClubShdUnlock = ClubShdUnlock;
            _modelMusic.ClubShdDjPoint = ClubShdDjPoint;
            _modelMusic.RubyShdActivation = RubyShdActivation;
            _modelMusic.RubyShdUnknown = RubyShdUnknown;
            _modelMusic.RubyShdUnlock = RubyShdUnlock;
            _modelMusic.RubyShdDjPoint = RubyShdDjPoint;
            _modelMusic.StreetEzActivation = StreetEzActivation;
            _modelMusic.StreetEzUnknown = StreetEzUnknown;
            _modelMusic.StreetHdActivation = StreetHdActivation;
            _modelMusic.StreetShdActivation = StreetShdActivation;
            _modelMusic.ClubEzActivation = ClubEzActivation;
            _modelMusic.ClubNmActivation = ClubNmActivation;
            _modelMusic.ClubHdActivation = ClubHdActivation;
            _modelMusic.ClubShdActivation = ClubShdActivation;
        }

        public override void Discard()
        {
            Id = _modelMusic.Id;
            Unknown = _modelMusic.Unknown;
            Name = _modelMusic.Name;
            Category = _modelMusic.Category;
            Duration = _modelMusic.Duration;
            Bpm = _modelMusic.Bpm;
            FileName = _modelMusic.FileName;
            New = _modelMusic.New;
            LicensePrice = _modelMusic.LicensePrice;
            RubyEzExr = _modelMusic.RubyEzExr;
            RubyEzActivation = _modelMusic.RubyEzActivation;
            RubyEzNotes = _modelMusic.RubyEzNotes;
            RubyEzUnknown = _modelMusic.RubyEzUnknown;
            RubyEzUnlock = _modelMusic.RubyEzUnlock;
            RubyNmExr = _modelMusic.RubyNmExr;
            RubyEzDjPoint = _modelMusic.RubyEzDjPoint;
            RubyNmNotes = _modelMusic.RubyNmNotes;
            RubyNmActivation = _modelMusic.RubyNmActivation;
            RubyNmUnknown = _modelMusic.RubyNmUnknown;
            RubyHdExr = _modelMusic.RubyHdExr;
            RubyNmUnlock = _modelMusic.RubyNmUnlock;
            RubyHdNotes = _modelMusic.RubyHdNotes;
            RubyNmDjPoint = _modelMusic.RubyNmDjPoint;
            RubyHdActivation = _modelMusic.RubyHdActivation;
            RubyShdExr = _modelMusic.RubyShdExr;
            RubyHdUnknown = _modelMusic.RubyHdUnknown;
            RubyShdNotes = _modelMusic.RubyShdNotes;
            RubyHdUnlock = _modelMusic.RubyHdUnlock;
            RubyHdDjPoint = _modelMusic.RubyHdDjPoint;
            StreetEzExr = _modelMusic.StreetEzExr;
            StreetEzUnlock = _modelMusic.StreetEzUnlock;
            StreetEzNotes = _modelMusic.StreetEzNotes;
            StreetEzDjPoint = _modelMusic.StreetEzDjPoint;
            SteetNmActivation = _modelMusic.SteetNmActivation;
            StreetNmExr = _modelMusic.StreetNmExr;
            StreetNmUnknown = _modelMusic.StreetNmUnknown;
            StreetNmNotes = _modelMusic.StreetNmNotes;
            StreetNmUnlock = _modelMusic.StreetNmUnlock;
            StreetNmDjPoint = _modelMusic.StreetNmDjPoint;
            StreetHdExr = _modelMusic.StreetHdExr;
            StreetHdUnknown = _modelMusic.StreetHdUnknown;
            StreetHdNotes = _modelMusic.StreetHdNotes;
            StreetHdUnlock = _modelMusic.StreetHdUnlock;
            StreetHdDjPoint = _modelMusic.StreetHdDjPoint;
            StreetShdExr = _modelMusic.StreetShdExr;
            StreetShdUnknown = _modelMusic.StreetShdUnknown;
            StreetShdNotes = _modelMusic.StreetShdNotes;
            StreetShdUnlock = _modelMusic.StreetShdUnlock;
            StreetShdDjPoint = _modelMusic.StreetShdDjPoint;
            ClubEzExr = _modelMusic.ClubEzExr;
            ClubEzUnknown = _modelMusic.ClubEzUnknown;
            ClubEzNotes = _modelMusic.ClubEzNotes;
            ClubEzUnlock = _modelMusic.ClubEzUnlock;
            ClubEzDjPoint = _modelMusic.ClubEzDjPoint;
            ClubNmExr = _modelMusic.ClubNmExr;
            ClubNmUnknown = _modelMusic.ClubNmUnknown;
            ClubNmNotes = _modelMusic.ClubNmNotes;
            ClubNmUnlock = _modelMusic.ClubNmUnlock;
            ClubNmDjPoint = _modelMusic.ClubNmDjPoint;
            ClubHdExr = _modelMusic.ClubHdExr;
            ClubHdUnknown = _modelMusic.ClubHdUnknown;
            ClubHdNotes = _modelMusic.ClubHdNotes;
            ClubHdUnlock = _modelMusic.ClubHdUnlock;
            ClubHdDjPoint = _modelMusic.ClubHdDjPoint;
            ClubShdExr = _modelMusic.ClubShdExr;
            ClubShdUnknown = _modelMusic.ClubShdUnknown;
            ClubShdNotes = _modelMusic.ClubShdNotes;
            ClubShdUnlock = _modelMusic.ClubShdUnlock;
            ClubShdDjPoint = _modelMusic.ClubShdDjPoint;
            RubyShdActivation = _modelMusic.RubyShdActivation;
            RubyShdUnknown = _modelMusic.RubyShdUnknown;
            RubyShdUnlock = _modelMusic.RubyShdUnlock;
            RubyShdDjPoint = _modelMusic.RubyShdDjPoint;
            StreetEzActivation = _modelMusic.StreetEzActivation;
            StreetEzUnknown = _modelMusic.StreetEzUnknown;
            StreetHdActivation = _modelMusic.StreetHdActivation;
            StreetShdActivation = _modelMusic.StreetShdActivation;
            ClubEzActivation = _modelMusic.ClubEzActivation;
            ClubNmActivation = _modelMusic.ClubNmActivation;
            ClubHdActivation = _modelMusic.ClubHdActivation;
            ClubShdActivation = _modelMusic.ClubShdActivation;
        }
    }
}
