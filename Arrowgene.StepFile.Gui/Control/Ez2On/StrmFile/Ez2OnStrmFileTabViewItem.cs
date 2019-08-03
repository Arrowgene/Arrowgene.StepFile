using Arrowgene.StepFile.Gui.Core.DynamicGridView;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StrmFile
{
    public abstract class Ez2OnStrmFileTabViewItem : DynamicGridViewItem
    {
        public Ez2OnStrmFileTabViewItem()
        {

        }

        public abstract void Save();

        public abstract void Discard();

    }
}
