namespace Arrowgene.StepFile.Core.Format
{
    using Arrowgene.StepFile.Core.Format.Sim;
    using Arrowgene.StepFile.Core.Model;
    using System.Collections.Generic;
    using System.IO;

    public class StepFileWriter
    {
        private Dictionary<string, IStepFileWriter> stepFileWriter;

        public StepFileWriter()
        {
            stepFileWriter = new Dictionary<string, IStepFileWriter>();
            stepFileWriter.Add(".sm", new SimFileWriter());
        }

        public void AddWriter(string fileExtension, IStepFileWriter writer)
        {
            this.stepFileWriter.Add(fileExtension, writer);
        }

        public void Write(StpFile stepFile, string destiantionPath)
        {
            string fileExtension = Path.GetExtension(destiantionPath);

            if (this.stepFileWriter.ContainsKey(fileExtension))
            {
                this.stepFileWriter[fileExtension].Write(stepFile, destiantionPath);
            }
        }

    }
}