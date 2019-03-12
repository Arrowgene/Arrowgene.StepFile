using System;

namespace Arrowgene.StepFile.Core.Ez2On.Archive.Ez2OnCrypto
{
    /// <summary>
    /// Statefull key which will be modified at runtime.
    /// </summary>
    public class Ez2OnCryptoKeyState : ICloneable
    {
        /// <summary>
        /// Return a new statefull key for the given extension.
        /// </summary>
        public static Ez2OnCryptoKeyState Get(Ez2OnCryptoExtension? extension)
        {
            switch (extension)
            {
                case Ez2OnCryptoExtension.png: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Png());
                case Ez2OnCryptoExtension.ogg: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Ogg());
                case Ez2OnCryptoExtension.jpg: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Jpg());
                case Ez2OnCryptoExtension.bin: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Bin());
                case Ez2OnCryptoExtension.pvi: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Pvi());
                case Ez2OnCryptoExtension.scr: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Scr());
                case Ez2OnCryptoExtension.bmp: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Bmp());
                case Ez2OnCryptoExtension.str: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Str());
                case Ez2OnCryptoExtension.dat: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Dat());
                case Ez2OnCryptoExtension.ptn: return new Ez2OnCryptoKeyState(Ez2OnCryptoKey.Ptn());
                default: return null;
            }
        }

        public UInt32[] Key { get; set; }
        public UInt32[] Output { get; set; }
        public UInt32[] Hash { get; set; }
        public UInt32[] Init { get; set; }
        public Ez2OnCryptoExtension? CryptoExtension { get; set; }

        public Ez2OnCryptoKeyState()
        {
            Key = new UInt32[4];
            Hash = new UInt32[72];
            Init = new UInt32[4];
            Output = new UInt32[4];
            CryptoExtension = null;
        }

        public Ez2OnCryptoKeyState(Ez2OnCryptoKey key) : this()
        {
            Key = ToUInt32(key.Key);
            Hash = ToUInt32(key.Hash);
            Init = ToUInt32(key.Init);
            CryptoExtension = key.CryptoExtension;
        }

        private UInt32[] ToUInt32(byte[] input)
        {
            int size = input.Length / sizeof(UInt32);
            UInt32[] uInts = new UInt32[size];
            for (var index = 0; index < size; index++)
            {
                uInts[index] = BitConverter.ToUInt32(input, index * sizeof(UInt32));
            }
            return uInts;
        }

        public object Clone()
        {
            return new Ez2OnCryptoKeyState
            {
                Key = (UInt32[]) Key.Clone(),
                Output = (UInt32[]) Output.Clone(),
                Init = (UInt32[]) Init.Clone(),
                Hash = (UInt32[]) Hash.Clone(),
                CryptoExtension = CryptoExtension
            };
        }
    }
}