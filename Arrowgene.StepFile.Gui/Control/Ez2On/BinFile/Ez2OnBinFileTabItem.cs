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

        public Ez2OnBinFileTabItem(Ez2OnModelItem modelItem) : this()
        {
            AddProperty("Id", modelItem.Id.ToString());
            AddProperty("Name", modelItem.Name);
            AddProperty("Image", modelItem.Image);
            AddProperty("Effect", modelItem.Effect);
        }

        public Ez2OnBinFileTabItem(string modelIdFilter) : this()
        {
            AddProperty("Filter", modelIdFilter);
        }

        public Ez2OnBinFileTabItem(Ez2OnModelCard modelCard) : this()
        {
            AddProperty("Id", modelCard.Id.ToString());
            AddProperty("Text", modelCard.Text);
        }

        public Ez2OnBinFileTabItem(Ez2OnModelQuest modelQuest) : this()
        {
            AddProperty("Id", modelQuest.Id.ToString());
            AddProperty("Title", modelQuest.Title);
            AddProperty("Mission", modelQuest.Mission);
        }

        public Ez2OnBinFileTabItem(Ez2onModelMusic modelMusic) : this()
        {
            AddProperty("Id", modelMusic.Id.ToString());
            AddProperty("Name", modelMusic.Name);
        }

        public Ez2OnBinFileTabItem(Ez2OnModelRadiomix modelRadiomix) : this()
        {
            AddProperty("Id", modelRadiomix.Id.ToString());
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
