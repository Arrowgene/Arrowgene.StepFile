using Arrowgene.StepFile.Gui.Core.DynamicGridView;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public abstract class Ez2OnBinFileTabViewItem : DynamicGridViewItem
    {
        public Ez2OnBinFileTabViewItem()
        {

        }

        public abstract void Save();

        public abstract void Discard();

    }
}
