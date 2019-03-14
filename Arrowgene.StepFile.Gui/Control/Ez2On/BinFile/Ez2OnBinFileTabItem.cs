using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabItem : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelItem _modelItem;

        public int Id { get; set; }
        public int Q { get; set; }
        public ItemType Type { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        public int U { get; set; }
        public string Image { get; set; }
        public int A { get; set; }
        public string Name { get; set; }
        public int B { get; set; }
        public int Duration { get; set; }
        public int Coins { get; set; }
        public int Level { get; set; }
        public int ExpPlus { get; set; }
        public int CoinPlus { get; set; }
        public int HpPlus { get; set; }
        public int ResiliencePlus { get; set; }
        public int DefensePlus { get; set; }
        public int K { get; set; }
        public int L { get; set; }
        public int M { get; set; }
        public int N { get; set; }
        public int O { get; set; }
        public int V { get; set; }
        public int W { get; set; }
        public int X { get; set; }
        public string Effect { get; set; }

        protected override object BindingSource => _modelItem;

        public Ez2OnBinFileTabItem(Ez2OnModelItem modelItem)
        {
            _modelItem = modelItem;
            Id = _modelItem.Id;
            Q = _modelItem.Q;
            Type = _modelItem.Type;
            S = _modelItem.S;
            T = _modelItem.T;
            U = _modelItem.U;
            Image = _modelItem.Image;
            A = _modelItem.A;
            Name = _modelItem.Name;
            B = _modelItem.B;
            Duration = _modelItem.Duration;
            Coins = _modelItem.Coins;
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
            W = _modelItem.W;
            X = _modelItem.X;
            Effect = _modelItem.Effect;
        }
    }
}
