namespace Arrowgene.StepFile.Plugin
{
    public interface ICryptoPlugin : IPlugin
    {
        int KeyLength { get; }
        byte[] Decrypt(byte[] data);
        byte[] Encrypt(byte[] data);
        void SetKey(byte[] key);
    }
}
