using System.Windows.Controls;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabRadiomix : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelItem _modelItem;
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
        public TextBox Q { get { if (_q == null) _q = Create("Q"); return _q; } }
        public TextBox Type { get { if (_type == null) _type = Create("Type"); return _type; } }
        public TextBox S { get { if (_s == null) _s = Create("S"); return _s; } }
        public TextBox T { get { if (_t == null) _t = Create("T"); return _t; } }
        public TextBox U { get { if (_u == null) _u = Create("U"); return _u; } }
        public TextBox Image { get { if (_image == null) _image = Create("Image"); return _image; } }
        public TextBox A { get { if (_a == null) _a = Create("A"); return _a; } }
        public TextBox Name { get { if (_name == null) _name = Create("Name"); return _name; } }
        public TextBox B { get { if (_b == null) _b = Create("B"); return _b; } }
        public TextBox Duration { get { if (_duration == null) _duration = Create("Duration"); return _duration; } }
        public TextBox Coins { get { if (_coins == null) _coins = Create("Coins"); return _coins; } }
        public TextBox Level { get { if (_level == null) _level = Create("Level"); return _level; } }
        public TextBox ExpPlus { get { if (_expPlus == null) _expPlus = Create("ExpPlus"); return _expPlus; } }
        public TextBox CoinPlus { get { if (_coinPlus == null) _coinPlus = Create("CoinPlus"); return _coinPlus; } }
        public TextBox HpPlus { get { if (_hpPlus == null) _hpPlus = Create("HpPlus"); return _hpPlus; } }
        public TextBox ResiliencePlus { get { if (_resiliencePlus == null) _resiliencePlus = Create("ResiliencePlus"); return _resiliencePlus; } }
        public TextBox DefensePlus { get { if (_defensePlus == null) _defensePlus = Create("DefensePlus"); return _defensePlus; } }
        public TextBox K { get { if (_k == null) _k = Create("K"); return _k; } }
        public TextBox L { get { if (_l == null) _l = Create("L"); return _l; } }
        public TextBox M { get { if (_m == null) _m = Create("M"); return _m; } }
        public TextBox N { get { if (_n == null) _n = Create("N"); return _n; } }
        public TextBox O { get { if (_o == null) _o = Create("O"); return _o; } }
        public TextBox V { get { if (_v == null) _v = Create("V"); return _v; } }
        public TextBox W { get { if (_w == null) _w = Create("W"); return _w; } }
        public TextBox X { get { if (_x == null) _x = Create("X"); return _x; } }
        public TextBox Effect { get { if (_effect == null) _effect = Create("Effect"); return _effect; } }

        public Ez2OnBinFileTabRadiomix(Ez2OnModelItem modelItem)
        {
            _modelItem = modelItem;
        }
    }
}
