using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabQuest : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelQuest _modelQuest;

        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public string Title { get; set; }
        public string Mission { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int K { get; set; }
        public int L { get; set; }
        public int M { get; set; }
        public int N { get; set; }
        public int O { get; set; }
        public int P { get; set; }
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        public int U { get; set; }
        public int V { get; set; }
        public int W { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Z1 { get; set; }
        public int Z2 { get; set; }
        public int Z3 { get; set; }
        public int Z4 { get; set; }
        public int Z5 { get; set; }
        public int Z6 { get; set; }
        public int Z7 { get; set; }
        public int Z8 { get; set; }
        public int Z9 { get; set; }
        public int Z10 { get; set; }
        public int Z11 { get; set; }

        protected override object BindingSource => _modelQuest;

        public Ez2OnBinFileTabQuest(Ez2OnModelQuest modelQuest)
        {
            _modelQuest = modelQuest;
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
