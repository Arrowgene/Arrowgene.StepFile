using System.Collections.Generic;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.DotBin
{
    public class Ez2OnDotBinTabItem
    {

        public List<Ez2OnDotBinTabProperty> Properties { get; }

        public Ez2OnDotBinTabItem()
        {
            Properties = new List<Ez2OnDotBinTabProperty>();
        }

        public Ez2OnDotBinTabItem(Item item) : this()
        {
            AddProperty("Name", item.Name);
            AddProperty("Image", item.Image);
            AddProperty("Id", item.Id.ToString());
        }

        private void AddProperty(string property, string value)
        {
            Properties.Add(new Ez2OnDotBinTabProperty()
            {
                Property = property,
                Value = value
            });
        }

    }
}
