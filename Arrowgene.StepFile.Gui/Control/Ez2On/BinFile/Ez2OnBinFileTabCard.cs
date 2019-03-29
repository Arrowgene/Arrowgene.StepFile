using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabCard : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelCard _cardBin;

        private int _id;
        private string _text;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }
        public Ez2OnModelCard Model => _cardBin;

        public Ez2OnBinFileTabCard(Ez2OnModelCard cardBin)
        {
            _cardBin = cardBin;
            Discard();
        }

        public override void Save()
        {
            _cardBin.Id = Id;
            _cardBin.Text = Text;
        }

        public override void Discard()
        {
            Id = _cardBin.Id;
            Text = _cardBin.Text;
        }
    }
}
