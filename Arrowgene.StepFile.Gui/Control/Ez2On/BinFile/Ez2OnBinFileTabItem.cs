using System.Collections.Generic;
using System.Windows;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabItem
    {

        public List<UIElement> Properties { get; }

        public Ez2OnBinFileTabItem()
        {
            Properties = new List<UIElement>();
        }

        public Ez2OnBinFileTabItem(Item item) : this()
        {
            AddProperty("Name", item.Name);
            AddProperty("Image", item.Image);
            AddProperty("Id", item.Id.ToString());
        }

        private void AddProperty(string property, string value)
        {
            Properties.Add(new Ez2OnBinFileTabProperty()
            {
                Property = property,
                Value = value
            });
        }

    }
}
