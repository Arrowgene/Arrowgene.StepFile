using System;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Model
{
    [Serializable]
    public class Ez2OnModelCard
    {
        public Ez2OnModelCard()
        {
            Id = -1;
        }

        public string Text { get; set; }
        public int Id { get; set; }
    }
}