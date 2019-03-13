using Arrowgene.Services.Logging;
using Arrowgene.StepFile.Plugin;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Archive
{
    public class Ez2OnArchiveCrypto
    {
        private IEz2OnArchiveCryptoPlugin _cryptoPlugin;
        private Ez2OnArchiveCryptoDetector _cryptoDetector;
        private Logger _logger;

        public int CryptoType => _cryptoPlugin.CryptoType;
        public string Name => _cryptoPlugin.Name;
        public bool CanEncrypt => _cryptoPlugin.CanEncrypt;
        public bool CanDecrypt => _cryptoPlugin.CanDecrypt;
        public IEz2OnArchiveCryptoPlugin CryptoPlugin => _cryptoPlugin;

        public Ez2OnArchiveCrypto(IEz2OnArchiveCryptoPlugin cryptoPlugin)
        {
            _cryptoPlugin = cryptoPlugin;
            _logger = LogProvider<Logger>.GetLogger(this);
            _cryptoDetector = new Ez2OnArchiveCryptoDetector();
        }

        public void Decrypt(Ez2OnArchiveFile file)
        {
            if (!_cryptoDetector.CanCrypt(file.Extension))
            {
                return;
            }
            file.Data = _cryptoPlugin.Decrypt(file.Data, file.Extension);
            file.Encrypted = false;
        }

        public void Encrypt(Ez2OnArchiveFile file)
        {
            if (!_cryptoDetector.CanCrypt(file.Extension))
            {
                return;
            }
            file.Data = _cryptoPlugin.Encrypt(file.Data, file.Extension);
            file.Encrypted = true;
        }
    }
}