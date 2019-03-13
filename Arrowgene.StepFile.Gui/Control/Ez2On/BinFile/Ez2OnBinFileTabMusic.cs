using System.Windows.Controls;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabMusic : Ez2OnBinFileTabViewItem
    {
        private Ez2onModelMusic _modelMusic;
        private TextBox _id;
        private TextBox _q;
        private TextBox _type;
        private TextBox _s;
        private TextBox _t;
        private TextBox _u;
        private TextBox _image;
        private TextBox _a;
        private TextBox _name;
        private TextBox _b;
        private TextBox _duration;
        private TextBox _coins;
        private TextBox _level;
        private TextBox _expPlus;
        private TextBox _coinPlus;
        private TextBox _hpPlus;
        private TextBox _resiliencePlus;
        private TextBox _defensePlus;
        private TextBox _k;
        private TextBox _l;
        private TextBox _m;
        private TextBox _n;
        private TextBox _o;
        private TextBox _v;
        private TextBox _w;
        private TextBox _x;
        private TextBox _effect;

        public TextBox Id { get { if (_id == null) _id = Create("Id"); return _id; } }
        public TextBox E1 { get { if (_q == null) _q = Create("Q"); return _q; } }
        public TextBox Name { get { if (_type == null) _type = Create("Type"); return _type; } }
        public TextBox Category { get { if (_s == null) _s = Create("S"); return _s; } }
        public TextBox Duration { get { if (_t == null) _t = Create("T"); return _t; } }
        public TextBox Bpm { get { if (_u == null) _u = Create("U"); return _u; } }
        public TextBox FileName { get { if (_image == null) _image = Create("Image"); return _image; } }
        public TextBox D1 { get { if (_a == null) _a = Create("A"); return _a; } }
        public TextBox D2 { get { if (_name == null) _name = Create("Name"); return _name; } }
        public TextBox RubyEzExr { get { if (_b == null) _b = Create("B"); return _b; } }
        public TextBox D4 { get { if (_duration == null) _duration = Create("Duration"); return _duration; } }
        public TextBox RubyEzNotes { get { if (_coins == null) _coins = Create("Coins"); return _coins; } }
        public TextBox D6 { get { if (_level == null) _level = Create("Level"); return _level; } }
        public TextBox D7 { get { if (_expPlus == null) _expPlus = Create("ExpPlus"); return _expPlus; } }
        public TextBox RubyNmExr { get { if (_coinPlus == null) _coinPlus = Create("CoinPlus"); return _coinPlus; } }
        public TextBox D9 { get { if (_hpPlus == null) _hpPlus = Create("HpPlus"); return _hpPlus; } }
        public TextBox RubyNmNotes { get { if (_resiliencePlus == null) _resiliencePlus = Create("ResiliencePlus"); return _resiliencePlus; } }
        public TextBox D11 { get { if (_defensePlus == null) _defensePlus = Create("DefensePlus"); return _defensePlus; } }
        public TextBox D12 { get { if (_k == null) _k = Create("K"); return _k; } }
        public TextBox RubyHdExr { get { if (_l == null) _l = Create("L"); return _l; } }
        public TextBox D14 { get { if (_m == null) _m = Create("M"); return _m; } }
        public TextBox RubyHdNotes { get { if (_n == null) _n = Create("N"); return _n; } }
        public TextBox D16 { get { if (_o == null) _o = Create("O"); return _o; } }
        public TextBox D17 { get { if (_v == null) _v = Create("V"); return _v; } }
        public TextBox RubyShdExr { get { if (_w == null) _w = Create("W"); return _w; } }
        public TextBox D19 { get { if (_x == null) _x = Create("X"); return _x; } }
        public TextBox RubyShdNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D21 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D22 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetEzExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D24 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetEzNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D26 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D27 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetNmExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D29 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetNmNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D31 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D32 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetHdExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D34 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetHdNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D36 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D37 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetShdExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D39 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox StreetShdNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D41 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D42 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubEzExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D44 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubEzNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D46 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D47 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubNmExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D49 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubNmNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D51 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D52 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubHdExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D54 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubHdNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D56 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D57 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubShdExr { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D59 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox ClubShdNotes { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox D61 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E2 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E3 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E4 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E5 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E6 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E7 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E8 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E9 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E10 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E11 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E12 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E13 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }
        public TextBox E14 { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }

        protected override object BindingSource => _modelMusic;

        public Ez2OnBinFileTabMusic(Ez2onModelMusic modelItem)
        {
            _modelMusic = modelItem;
        }
    }
}
