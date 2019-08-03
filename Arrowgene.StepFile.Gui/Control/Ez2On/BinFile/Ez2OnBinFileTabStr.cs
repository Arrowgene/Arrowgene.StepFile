using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabStr : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelStr _strBin;

        private int _id;
        private string _text;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }
        public Ez2OnModelStr Model => _strBin;

        public Ez2OnBinFileTabStr(Ez2OnModelStr strBin)
        {
            _strBin = strBin;
            Discard();
        }

        public override void Save()
        {
            _strBin.Id = Id;
            _strBin.Text = Text;
        }

        public override void Discard()
        {
            Id = _strBin.Id;
            Text = _strBin.Text;
        }
    }
}
