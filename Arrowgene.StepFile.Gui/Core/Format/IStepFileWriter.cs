namespace Arrowgene.StepFile.Core.Format
{
    using Arrowgene.StepFile.Core.Model;
    public interface IStepFileWriter
    {
        void Write(StpFile stepFile, string destinationPath);
    }
}
