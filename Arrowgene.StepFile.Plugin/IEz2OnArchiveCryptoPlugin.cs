namespace Arrowgene.StepFile.Plugin
{
    public interface IEz2OnArchiveCryptoPlugin : IPlugin
    {
        byte[] Decrypt(byte[] data, string fileExtension);
        byte[] Encrypt(byte[] data, string fileExtension);
        int CryptoType { get; }
        bool CanDecrypt { get; }
        bool CanEncrypt { get; }
    }
}
