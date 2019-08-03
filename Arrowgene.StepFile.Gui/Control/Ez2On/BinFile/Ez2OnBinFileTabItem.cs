using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabItem : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelItem _modelItem;

        private int _id;
        private int _enabled;
        private ItemType _type;
        private int _s;
        private int _t;
        private int _u;
        private string _image;
        private int _a;
        private string _name;
        private ItemCurrencyType _currency;
        private int _duration;
        private int _price;
        private int _level;
        private int _expPlus;
        private int _coinPlus;
        private int _hpPlus;
        private int _resiliencePlus;
        private int _defensePlus;
        private int _k;
        private int _l;
        private int _m;
        private int _n;
        private int _o;
        private int _v;
        private int _djPointPlus;
        private int _x;
        private string _effect;

        public Ez2OnModelItem Model => _modelItem;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public int Enabled { get { return _enabled; } set { _enabled = value; OnPropertyChanged("Enabled"); } }
        public ItemType Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        public int S { get { return _s; } set { _s = value; OnPropertyChanged("S"); } }
        public int T { get { return _t; } set { _t = value; OnPropertyChanged("T"); } }
        public int U { get { return _u; } set { _u = value; OnPropertyChanged("U"); } }
        public string Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public int A { get { return _a; } set { _a = value; OnPropertyChanged("A"); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public ItemCurrencyType Currency { get { return _currency; } set { _currency = value; OnPropertyChanged("Currency"); } }
        public int Duration { get { return _duration; } set { _duration = value; OnPropertyChanged("Duration"); } }
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged("Price"); } }
        public int Level { get { return _level; } set { _level = value; OnPropertyChanged("Level"); } }
        public int ExpPlus { get { return _expPlus; } set { _expPlus = value; OnPropertyChanged("ExpPlus"); } }
        public int CoinPlus { get { return _coinPlus; } set { _coinPlus = value; OnPropertyChanged("CoinPlus"); } }
        public int HpPlus { get { return _hpPlus; } set { _hpPlus = value; OnPropertyChanged("HpPlus"); } }
        public int ResiliencePlus { get { return _resiliencePlus; } set { _resiliencePlus = value; OnPropertyChanged("ResiliencePlus"); } }
        public int DefensePlus { get { return _defensePlus; } set { _defensePlus = value; OnPropertyChanged("DefensePlus"); } }
        public int K { get { return _k; } set { _k = value; OnPropertyChanged("K"); } }
        public int L { get { return _l; } set { _l = value; OnPropertyChanged("L"); } }
        public int M { get { return _m; } set { _m = value; OnPropertyChanged("M"); } }
        public int N { get { return _n; } set { _n = value; OnPropertyChanged("N"); } }
        public int O { get { return _o; } set { _o = value; OnPropertyChanged("O"); } }
        public int V { get { return _v; } set { _v = value; OnPropertyChanged("V"); } }
        public int DjPointPlus { get { return _djPointPlus; } set { _djPointPlus = value; OnPropertyChanged("DjPointPlus"); } }
        public int X { get { return _x; } set { _x = value; OnPropertyChanged("X"); } }
        public string Effect { get { return _effect; } set { _effect = value; OnPropertyChanged("Effect"); } }

        public Ez2OnBinFileTabItem(Ez2OnModelItem modelItem)
        {
            _modelItem = modelItem;
            Discard();
        }

        public override void Save()
        {
            _modelItem.Id = Id;
            _modelItem.Enabled = Enabled;
            _modelItem.Type = Type;
            _modelItem.S = S;
            _modelItem.T = T;
            _modelItem.U = U;
            _modelItem.Image = Image;
            _modelItem.A = A;
            _modelItem.Name = Name;
            _modelItem.Currency = Currency;
            _modelItem.Duration = Duration;
            _modelItem.Price = Price;
            _modelItem.Level = Level;
            _modelItem.ExpPlus = ExpPlus;
            _modelItem.CoinPlus = CoinPlus;
            _modelItem.HpPlus = HpPlus;
            _modelItem.ResiliencePlus = ResiliencePlus;
            _modelItem.DefensePlus = DefensePlus;
            _modelItem.K = K;
            _modelItem.L = L;
            _modelItem.M = M;
            _modelItem.N = N;
            _modelItem.O = O;
            _modelItem.V = V;
            _modelItem.DjPointPlus = DjPointPlus;
            _modelItem.X = X;
            _modelItem.Effect = Effect;
        }

        public override void Discard()
        {
            Id = _modelItem.Id;
            Enabled = _modelItem.Enabled;
            Type = _modelItem.Type;
            S = _modelItem.S;
            T = _modelItem.T;
            U = _modelItem.U;
            Image = _modelItem.Image;
            A = _modelItem.A;
            Name = _modelItem.Name;
            Currency = _modelItem.Currency;
            Duration = _modelItem.Duration;
            Price = _modelItem.Price;
            Level = _modelItem.Level;
            ExpPlus = _modelItem.ExpPlus;
            CoinPlus = _modelItem.CoinPlus;
            HpPlus = _modelItem.HpPlus;
            ResiliencePlus = _modelItem.ResiliencePlus;
            DefensePlus = _modelItem.DefensePlus;
            K = _modelItem.K;
            L = _modelItem.L;
            M = _modelItem.M;
            N = _modelItem.N;
            O = _modelItem.O;
            V = _modelItem.V;
            DjPointPlus = _modelItem.DjPointPlus;
            X = _modelItem.X;
            Effect = _modelItem.Effect;
        }
    }
}
