using Arrowgene.StepFile.Core.DynamicGridView;

namespace Arrowgene.StepFile.Control.ArchiveTab
{
    public class ArchiveTabItem : DynamicGridViewItem
    {
        private ArchiveTabItemName _itemName;

        public ArchiveTabItemName ItemName
        {
            get
            {
                if (_itemName == null)
                {
                    _itemName = new ArchiveTabItemName();
                    _itemName.Text = _itemTextName;
                    _itemName.Image = _itemImageName;
                }
                return _itemName;
            }
        }

        public string ItemTextName
        {
            get { return _itemTextName; }
            set { _itemTextName = value; if (_itemName == null) { return; } _itemName.Text = _itemTextName; }
        }

        public string ItemImageName
        {
            get { return _itemImageName; }
            set { _itemImageName = value; if (_itemName == null) { return; } _itemName.Image = _itemImageName; }
        }

        private string _itemTextName;
        private string _itemImageName;

        public ArchiveTabItem()
        {
        }
    }
}
