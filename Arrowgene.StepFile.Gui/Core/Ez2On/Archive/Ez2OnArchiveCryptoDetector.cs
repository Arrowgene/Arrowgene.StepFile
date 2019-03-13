using System.Collections.Generic;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Archive
{
    public class Ez2OnArchiveCryptoDetector
    {
        private Dictionary<string, List<byte[]>> _signatures;

        public Ez2OnArchiveCryptoDetector()
        {
            _signatures = new Dictionary<string, List<byte[]>>();
            LoadSignatures();
        }

        public bool CanCrypt(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                return false;
            }
            return _signatures.ContainsKey(extension.ToLowerInvariant());
        }

        public bool? IsEncrypted(string extension, byte[] data)
        {
            if (extension == null || data == null)
            {
                return null;
            }
            extension = extension.ToLowerInvariant();
            if (!_signatures.ContainsKey(extension))
            {
                return null;
            }
            List<byte[]> possibleHeader = _signatures[extension];
            foreach (byte[] header in possibleHeader)
            {
                bool equal = true;
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] != data[i])
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal)
                {
                    return false;
                }
            }
            return true;
        }

        private void LoadSignatures()
        {
            _signatures.Add(".png", new List<byte[]>
            {
                new byte[] {0x89, 0x50, 0x4E, 0x47}
            });
            _signatures.Add(".bin", new List<byte[]>
            {
                new byte[] {0x45, 0x5A, 0x49, 0x44, 0x41, 0x54, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00}, //EZIDATA
                new byte[] {0x4D, 0x5F, 0x51, 0x55, 0x45, 0x53, 0x54, 0x00, 0x00, 0x00, 0x00, 0x00}, //M_QUEST
                new byte[] {0x4D, 0x5F, 0x4D, 0x55, 0x53, 0x49, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00}, //M_MUSIC
                new byte[] {0x4D, 0x5F, 0x43, 0x41, 0x52, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //M_CARD
                new byte[] {0x4D, 0x5F, 0x49, 0x54, 0x45, 0x4D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //M_ITEM
                new byte[] {0x4D, 0x5F, 0x49, 0x44, 0x5F, 0x46, 0x49, 0x4C, 0x54, 0x45, 0x52, 0x00}, //M_ID_FILTER
            });
            _signatures.Add(".str", new List<byte[]>
            {
                new byte[] {0x53, 0x54, 0x52, 0x4D} //STRM
            });
            _signatures.Add(".dat", new List<byte[]>
            {
            });
            _signatures.Add(".bmp", new List<byte[]>
            {
                new byte[] {0x42, 0x4D} //BM
            });
            _signatures.Add(".jpg", new List<byte[]>
            {
                new byte[] {0xFF, 0xD8, 0xFF, 0xE0}
            });
            _signatures.Add(".ogg", new List<byte[]>
            {
                new byte[] {0x4F, 0x67, 0x67, 0x53} // OggS
            });
            _signatures.Add(".pvi", new List<byte[]>
            {

            });
            _signatures.Add(".scr", new List<byte[]>
            {
                new byte[] {0x53, 0x43, 0x52, 0x30} //SCR0
            });
            _signatures.Add(".ptn", new List<byte[]>
            {
                new byte[] {0x50, 0x54, 0x4E, 0x45} // PTNE
            });
        }

    }
}
