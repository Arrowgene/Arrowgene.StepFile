using System.Collections.Generic;

namespace Arrowgene.StepFile.Core.Model
{
    /// <summary>
    /// A model for a single line in a step chart. 
    /// Contains several steps, the number depending on what game mode the line is for. 
    /// There is a line at every fraction of a beat.
    /// </summary>
    public class Line
    {
        public Line(StpFile stepFile)
        {
            this.StepFile = stepFile;
            this.Steps = new List<Step>();
            this.Index = 0;
        }


        public StpFile StepFile { get; private set; }
        public int Index { get; set; }
        public List<Step> Steps { get; set; }

        public bool IsValid()
        {
            bool isValid = true;

            foreach (Step step in this.Steps)
            {
                if (!step.IsValid())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}