using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabRadiomix : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelRadiomix _modelRadioMix;
        private int _radiomixId;
        private int _b;
        private int _c;
        private int _d;
        private int _e;
        private int _song1Id;
        private int _song1RubyNotes;
        private int _song1StreetNotes;
        private int _song1ClubNotes;
        private int _song1Club8KNotes;
        private int _song2Id;
        private int _song2RubyNotes;
        private int _song2StreetNotes;
        private int _song2ClubNotes;
        private int _song2Club8KNotes;
        private int _song3Id;
        private int _song3RubyNotes;
        private int _song3StreetNotes;
        private int _song3ClubNotes;
        private int _song3Club8KNotes;
        private int _song4Id;
        private int _song4RubyNotes;
        private int _song4StreetNotes;
        private int _song4ClubNotes;
        private int _song4Club8KNotes;

        public Ez2OnModelRadiomix Model => _modelRadioMix;
        public int RadiomixId { get { return _radiomixId; } set { _radiomixId = value; OnPropertyChanged("RadiomixId"); } }
        public int B { get { return _b; } set { _b = value; OnPropertyChanged("B"); } }
        public int C { get { return _c; } set { _c = value; OnPropertyChanged("C"); } }
        public int D { get { return _d; } set { _d = value; OnPropertyChanged("D"); } }
        public int E { get { return _e; } set { _e = value; OnPropertyChanged("E"); } }
        public int Song1Id { get { return _song1Id; } set { _song1Id = value; OnPropertyChanged("Song1Id"); } }
        public int Song1RubyNotes { get { return _song1RubyNotes; } set { _song1RubyNotes = value; OnPropertyChanged("Song1RubyNotes"); OnPropertyChanged("TotalRubyNotes"); } }
        public int Song1StreetNotes { get { return _song1StreetNotes; } set { _song1StreetNotes = value; OnPropertyChanged("Song1StreetNotes"); OnPropertyChanged("TotalStreetNotes"); } }
        public int Song1ClubNotes { get { return _song1ClubNotes; } set { _song1ClubNotes = value; OnPropertyChanged("Song1ClubNotes"); OnPropertyChanged("TotalClubNotes"); } }
        public int Song1Club8KNotes { get { return _song1Club8KNotes; } set { _song1Club8KNotes = value; OnPropertyChanged("Song1Club8KNotes"); OnPropertyChanged("TotalCLub8KNotes"); } }
        public int Song2Id { get { return _song2Id; } set { _song2Id = value; OnPropertyChanged("Song2Id"); } }
        public int Song2RubyNotes { get { return _song2RubyNotes; } set { _song2RubyNotes = value; OnPropertyChanged("Song2RubyNotes"); OnPropertyChanged("TotalRubyNotes"); } }
        public int Song2StreetNotes { get { return _song2StreetNotes; } set { _song2StreetNotes = value; OnPropertyChanged("Song2StreetNotes"); OnPropertyChanged("TotalStreetNotes"); } }
        public int Song2ClubNotes { get { return _song2ClubNotes; } set { _song2ClubNotes = value; OnPropertyChanged("Song2ClubNotes"); OnPropertyChanged("TotalClubNotes"); } }
        public int Song2Club8KNotes { get { return _song2Club8KNotes; } set { _song2Club8KNotes = value; OnPropertyChanged("Song2Club8KNotes"); OnPropertyChanged("TotalCLub8KNotes"); } }
        public int Song3Id { get { return _song3Id; } set { _song3Id = value; OnPropertyChanged("Song3Id"); } }
        public int Song3RubyNotes { get { return _song3RubyNotes; } set { _song3RubyNotes = value; OnPropertyChanged("Song3RubyNotes"); OnPropertyChanged("TotalRubyNotes"); } }
        public int Song3StreetNotes { get { return _song3StreetNotes; } set { _song3StreetNotes = value; OnPropertyChanged("Song3StreetNotes"); OnPropertyChanged("TotalStreetNotes"); } }
        public int Song3ClubNotes { get { return _song3ClubNotes; } set { _song3ClubNotes = value; OnPropertyChanged("Song3ClubNotes"); OnPropertyChanged("TotalClubNotes"); } }
        public int Song3Club8KNotes { get { return _song3Club8KNotes; } set { _song3Club8KNotes = value; OnPropertyChanged("Song3Club8KNotes"); OnPropertyChanged("TotalCLub8KNotes"); } }
        public int Song4Id { get { return _song4Id; } set { _song4Id = value; OnPropertyChanged("Song4Id"); } }
        public int Song4RubyNotes { get { return _song4RubyNotes; } set { _song4RubyNotes = value; OnPropertyChanged("Song4RubyNotes"); OnPropertyChanged("TotalRubyNotes"); } }
        public int Song4StreetNotes { get { return _song4StreetNotes; } set { _song4StreetNotes = value; OnPropertyChanged("Song4StreetNotes"); OnPropertyChanged("TotalStreetNotes"); } }
        public int Song4ClubNotes { get { return _song4ClubNotes; } set { _song4ClubNotes = value; OnPropertyChanged("Song4ClubNotes"); OnPropertyChanged("TotalClubNotes"); } }
        public int Song4Club8KNotes { get { return _song4Club8KNotes; } set { _song4Club8KNotes = value; OnPropertyChanged("Song4Club8KNotes"); OnPropertyChanged("TotalCLub8KNotes"); } }

        public int TotalRubyNotes => Song1RubyNotes + Song2RubyNotes + Song3RubyNotes + Song4RubyNotes;
        public int TotalStreetNotes => Song1StreetNotes + Song2StreetNotes + Song3StreetNotes + Song4StreetNotes;
        public int TotalClubNotes => Song1ClubNotes + Song2ClubNotes + Song3ClubNotes + Song4ClubNotes;
        public int TotalCLub8KNotes => Song1Club8KNotes + Song2Club8KNotes + Song3Club8KNotes + Song4Club8KNotes;


        public Ez2OnBinFileTabRadiomix(Ez2OnModelRadiomix modelRadiomix)
        {
            _modelRadioMix = modelRadiomix;
            Discard();
        }

        public override void Save()
        {
            _modelRadioMix.RadiomixId = RadiomixId;
            _modelRadioMix.B = B;
            _modelRadioMix.C = C;
            _modelRadioMix.D = D;
            _modelRadioMix.E = E;
            _modelRadioMix.Song1Id = Song1Id;
            _modelRadioMix.Song1RubyNotes = Song1RubyNotes;
            _modelRadioMix.Song1StreetNotes = Song1StreetNotes;
            _modelRadioMix.Song1ClubNotes = Song1ClubNotes;
            _modelRadioMix.Song1Club8KNotes = Song1Club8KNotes;
            _modelRadioMix.Song2Id = Song2Id;
            _modelRadioMix.Song2RubyNotes = Song2RubyNotes;
            _modelRadioMix.Song2StreetNotes = Song2StreetNotes;
            _modelRadioMix.Song2ClubNotes = Song2ClubNotes;
            _modelRadioMix.Song2Club8KNotes = Song2Club8KNotes;
            _modelRadioMix.Song3Id = Song3Id;
            _modelRadioMix.Song3RubyNotes = Song3RubyNotes;
            _modelRadioMix.Song3StreetNotes = Song3StreetNotes;
            _modelRadioMix.Song3ClubNotes = Song3ClubNotes;
            _modelRadioMix.Song3Club8KNotes = Song3Club8KNotes;
            _modelRadioMix.Song4Id = Song4Id;
            _modelRadioMix.Song4RubyNotes = Song4RubyNotes;
            _modelRadioMix.Song4StreetNotes = Song4StreetNotes;
            _modelRadioMix.Song4ClubNotes = Song4ClubNotes;
            _modelRadioMix.Song4Club8KNotes = Song4Club8KNotes;
        }

        public override void Discard()
        {
            RadiomixId = _modelRadioMix.RadiomixId;
            B = _modelRadioMix.B;
            C = _modelRadioMix.C;
            D = _modelRadioMix.D;
            E = _modelRadioMix.E;
            Song1Id = _modelRadioMix.Song1Id;
            Song1RubyNotes = _modelRadioMix.Song1RubyNotes;
            Song1StreetNotes = _modelRadioMix.Song1StreetNotes;
            Song1ClubNotes = _modelRadioMix.Song1ClubNotes;
            Song1Club8KNotes = _modelRadioMix.Song1Club8KNotes;
            Song2Id = _modelRadioMix.Song2Id;
            Song2RubyNotes = _modelRadioMix.Song2RubyNotes;
            Song2StreetNotes = _modelRadioMix.Song2StreetNotes;
            Song2ClubNotes = _modelRadioMix.Song2ClubNotes;
            Song2Club8KNotes = _modelRadioMix.Song2Club8KNotes;
            Song3Id = _modelRadioMix.Song3Id;
            Song3RubyNotes = _modelRadioMix.Song3RubyNotes;
            Song3StreetNotes = _modelRadioMix.Song3StreetNotes;
            Song3ClubNotes = _modelRadioMix.Song3ClubNotes;
            Song3Club8KNotes = _modelRadioMix.Song3Club8KNotes;
            Song4Id = _modelRadioMix.Song4Id;
            Song4RubyNotes = _modelRadioMix.Song4RubyNotes;
            Song4StreetNotes = _modelRadioMix.Song4StreetNotes;
            Song4ClubNotes = _modelRadioMix.Song4ClubNotes;
            Song4Club8KNotes = _modelRadioMix.Song4Club8KNotes;
        }
    }
}
