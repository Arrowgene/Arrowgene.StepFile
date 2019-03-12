namespace Arrowgene.StepFile.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for a single difficulty in a step file. 
    /// Contains step data, and meta data specific to the difficulty.
    /// </summary>
    public class Difficulty
    {
        public Difficulty(StpFile stepFile)
        {
            this.StepFile = stepFile;
            this.Measures = new List<Measure>();
            this.Level = 0;
            this.ChartType = ChartType.None;
        }

        public StpFile StepFile { get; private set; }
        public int Duration { get; set; }
        public int Level { get; set; }
        public ChartType ChartType { get; set; }
        public List<Measure> Measures { get; set; }

        public bool IsValid()
        {
            bool isValid = true;

    

            foreach (Measure measure in this.Measures)
            {
                if (!measure.IsValid())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }


        public int GetNoteCount()
        {
            int count = 0;
            foreach (Measure measure in Measures)
            {
                foreach (Line line in measure.Lines)
                {
                    foreach (Step step in line.Steps)
                    {
                        if (step.StepType != StepType.None)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }



    }
}
