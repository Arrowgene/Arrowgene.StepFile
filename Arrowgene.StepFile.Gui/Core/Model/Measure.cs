namespace Arrowgene.StepFile.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for all the data contained within a single measure of a step chart. 
    /// A measure is equivalent to a musical measure in the song: 
    /// contains a set number of beats, and step lines for each beat step(or fraction of a beat).
    /// </summary>
    public class Measure
    {
        public Measure(StpFile stepFile)
        {
            this.StepFile = stepFile;
            this.Lines = new List<Line>();
            this.Index = 0;
        }

        public StpFile StepFile { get; private set; }
        public int Index { get; set; }
        public List<Line> Lines { get; set; }

        public bool IsValid()
        {
            bool isValid = true;

            foreach (Line line in this.Lines)
            {
                if (!line.IsValid())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}