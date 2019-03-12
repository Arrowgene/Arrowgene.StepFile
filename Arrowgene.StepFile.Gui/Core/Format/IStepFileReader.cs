namespace Arrowgene.StepFile.Core.Format
{
    using Arrowgene.StepFile.Core.Model;

    public interface IStepFileReader
    {
        StpFile Read(byte[] file);

    }
}
