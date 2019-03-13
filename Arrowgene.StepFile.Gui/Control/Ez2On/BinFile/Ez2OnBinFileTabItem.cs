using System;
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
            AddProperty("Id", modelItem.Id.ToString(), (val) => { modelItem.Id = val; });
            AddProperty("Name", modelItem.Name, (val) => { modelItem.Name = val; });
            AddProperty("Image", modelItem.Image, (val) => { modelItem.Image = val; });
            AddProperty("Effect", modelItem.Effect, (val) => { modelItem.Effect = val; });
        }
        
        public Ez2OnBinFileTabItem(string modelIdFilter) : this()
        {
            AddProperty("Filter", modelIdFilter, (val) => { modelIdFilter = val; });
        }

        public Ez2OnBinFileTabItem(Ez2OnModelCard modelCard) : this()
        {
            AddProperty("Id", modelCard.Id.ToString(), (val) => { modelCard.Id = val; });
            AddProperty("Text", modelCard.Text, (val) => { modelCard.Text = val; });
        }

        public Ez2OnBinFileTabItem(Ez2OnModelQuest modelQuest) : this()
        {
            AddProperty("Id", modelQuest.Id.ToString(), (val) => { modelQuest.Id = val; });
            AddProperty("Title", modelQuest.Title, (val) => { modelQuest.Title = val; });
            AddProperty("Mission", modelQuest.Mission, (val) => { modelQuest.Mission = val; });
        }

        public Ez2OnBinFileTabItem(Ez2onModelMusic modelMusic) : this()
        {
            AddProperty("Id", modelMusic.Id.ToString(), (val) => { modelMusic.Id = val; });
            AddProperty("Name", modelMusic.Name, (val) => { modelMusic.Name = val; });
        }

        public Ez2OnBinFileTabItem(Ez2OnModelRadiomix modelRadiomix) : this()
        {
            AddProperty("Id", modelRadiomix.Id.ToString(), (val) => { modelRadiomix.Id = val; });
        }

        private void AddProperty(string property, string value, Action<int> setter)
        {
            Properties.Add(new Ez2OnBinFileTabProperty(property, value, setter));
        }

        private void AddProperty(string property, string value, Action<string> setter)
        {
            Properties.Add(new Ez2OnBinFileTabProperty(property, value, setter));
        }
    }
}
