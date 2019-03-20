using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabQuest : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelQuest _modelQuest;
        private int _id;
        private int _a;
        private int _b;
        private int _c;
        private int _d;
        private string _title;
        private string _mission;
        private int _g;
        private int _h;
        private int _i;
        private int _j;
        private int _k;
        private int _l;
        private int _m;
        private int _n;
        private int _o;
        private int _p;
        private int _q;
        private int _r;
        private int _s;
        private int _t;
        private int _u;
        private int _v;
        private int _w;
        private int _x;
        private int _y;
        private int _z;
        private int _z1;
        private int _z2;
        private int _z3;
        private int _z4;
        private int _z5;
        private int _z6;
        private int _z7;
        private int _z8;
        private int _z9;
        private int _z10;
        private int _z11;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public int A { get { return _a; } set { _a = value; OnPropertyChanged("A"); } }
        public int B { get { return _b; } set { _b = value; OnPropertyChanged("B"); } }
        public int C { get { return _c; } set { _c = value; OnPropertyChanged("C"); } }
        public int D { get { return _d; } set { _d = value; OnPropertyChanged("D"); } }
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged("Title"); } }
        public string Mission { get { return _mission; } set { _mission = value; OnPropertyChanged("Mission"); } }
        public int G { get { return _g; } set { _g = value; OnPropertyChanged("G"); } }
        public int H { get { return _h; } set { _h = value; OnPropertyChanged("H"); } }
        public int I { get { return _i; } set { _i = value; OnPropertyChanged("I"); } }
        public int J { get { return _j; } set { _j = value; OnPropertyChanged("J"); } }
        public int K { get { return _k; } set { _k = value; OnPropertyChanged("K"); } }
        public int L { get { return _l; } set { _l = value; OnPropertyChanged("L"); } }
        public int M { get { return _m; } set { _m = value; OnPropertyChanged("M"); } }
        public int N { get { return _n; } set { _n = value; OnPropertyChanged("N"); } }
        public int O { get { return _o; } set { _o = value; OnPropertyChanged("O"); } }
        public int P { get { return _p; } set { _p = value; OnPropertyChanged("P"); } }
        public int Q { get { return _q; } set { _q = value; OnPropertyChanged("Q"); } }
        public int R { get { return _r; } set { _r = value; OnPropertyChanged("R"); } }
        public int S { get { return _s; } set { _s = value; OnPropertyChanged("S"); } }
        public int T { get { return _t; } set { _t = value; OnPropertyChanged("T"); } }
        public int U { get { return _u; } set { _u = value; OnPropertyChanged("U"); } }
        public int V { get { return _v; } set { _v = value; OnPropertyChanged("V"); } }
        public int W { get { return _w; } set { _w = value; OnPropertyChanged("W"); } }
        public int X { get { return _x; } set { _x = value; OnPropertyChanged("X"); } }
        public int Y { get { return _y; } set { _y = value; OnPropertyChanged("Y"); } }
        public int Z { get { return _z; } set { _z = value; OnPropertyChanged("Z"); } }
        public int Z1 { get { return _z1; } set { _z1 = value; OnPropertyChanged("Z1"); } }
        public int Z2 { get { return _z2; } set { _z2 = value; OnPropertyChanged("Z2"); } }
        public int Z3 { get { return _z3; } set { _z3 = value; OnPropertyChanged("Z3"); } }
        public int Z4 { get { return _z4; } set { _z4 = value; OnPropertyChanged("Z4"); } }
        public int Z5 { get { return _z5; } set { _z5 = value; OnPropertyChanged("Z5"); } }
        public int Z6 { get { return _z6; } set { _z6 = value; OnPropertyChanged("Z6"); } }
        public int Z7 { get { return _z7; } set { _z7 = value; OnPropertyChanged("Z7"); } }
        public int Z8 { get { return _z8; } set { _z7 = value; OnPropertyChanged("Z8"); } }
        public int Z9 { get { return _z9; } set { _z9 = value; OnPropertyChanged("Z9"); } }
        public int Z10 { get { return _z10; } set { _z10 = value; OnPropertyChanged("Z10"); } }
        public int Z11 { get { return _z11; } set { _z11 = value; OnPropertyChanged("Z11"); } }

        public Ez2OnBinFileTabQuest(Ez2OnModelQuest modelQuest)
        {
            _modelQuest = modelQuest;
            Discard();
        }

        public override void Save()
        {
            _modelQuest.Id = Id;
            _modelQuest.A = A;
            _modelQuest.B = B;
            _modelQuest.C = C;
            _modelQuest.D = D;
            _modelQuest.Title = Title;
            _modelQuest.Mission = Mission;
            _modelQuest.G = G;
            _modelQuest.H = H;
            _modelQuest.I = I;
            _modelQuest.J = J;
            _modelQuest.K = K;
            _modelQuest.L = L;
            _modelQuest.M = M;
            _modelQuest.N = N;
            _modelQuest.O = O;
            _modelQuest.P = P;
            _modelQuest.Q = Q;
            _modelQuest.R = R;
            _modelQuest.S = S;
            _modelQuest.T = T;
            _modelQuest.U = U;
            _modelQuest.V = V;
            _modelQuest.W = W;
            _modelQuest.X = X;
            _modelQuest.Y = Y;
            _modelQuest.Z = Z;
            _modelQuest.Z1 = Z1;
            _modelQuest.Z2 = Z2;
            _modelQuest.Z3 = Z3;
            _modelQuest.Z4 = Z4;
            _modelQuest.Z5 = Z5;
            _modelQuest.Z6 = Z6;
            _modelQuest.Z7 = Z7;
            _modelQuest.Z8 = Z8;
            _modelQuest.Z9 = Z9;
            _modelQuest.Z10 = Z10;
            _modelQuest.Z11 = Z11;
        }

        public override void Discard()
        {
            Id = _modelQuest.Id;
            A = _modelQuest.A;
            B = _modelQuest.B;
            C = _modelQuest.C;
            D = _modelQuest.D;
            Title = _modelQuest.Title;
            Mission = _modelQuest.Mission;
            G = _modelQuest.G;
            H = _modelQuest.H;
            I = _modelQuest.I;
            J = _modelQuest.J;
            K = _modelQuest.K;
            L = _modelQuest.L;
            M = _modelQuest.M;
            N = _modelQuest.N;
            O = _modelQuest.O;
            P = _modelQuest.P;
            Q = _modelQuest.Q;
            R = _modelQuest.R;
            S = _modelQuest.S;
            T = _modelQuest.T;
            U = _modelQuest.U;
            V = _modelQuest.V;
            W = _modelQuest.W;
            X = _modelQuest.X;
            Y = _modelQuest.Y;
            Z = _modelQuest.Z;
            Z1 = _modelQuest.Z1;
            Z2 = _modelQuest.Z2;
            Z3 = _modelQuest.Z3;
            Z4 = _modelQuest.Z4;
            Z5 = _modelQuest.Z5;
            Z6 = _modelQuest.Z6;
            Z7 = _modelQuest.Z7;
            Z8 = _modelQuest.Z8;
            Z9 = _modelQuest.Z9;
            Z10 = _modelQuest.Z10;
            Z11 = _modelQuest.Z11;
        }
    }
}
