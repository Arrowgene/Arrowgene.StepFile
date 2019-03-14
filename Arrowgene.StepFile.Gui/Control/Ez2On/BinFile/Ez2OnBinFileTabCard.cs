using System.Windows.Controls;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabCard : Ez2OnBinFileTabViewItem
    {
        private Ez2OnModelCard _cardBin;

        public int Id { get; set; }
        public string Text { get; set; }

        protected override object BindingSource => _cardBin;

        public Ez2OnBinFileTabCard(Ez2OnModelCard cardBin)
        {
            _cardBin = cardBin;
            Id = _cardBin.Id;
            Text = _cardBin.Text;
        }
    }
}
