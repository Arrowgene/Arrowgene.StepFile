using System;

namespace Arrowgene.StepFile.Core.Format.Sdo
{
    public class SdoCrypto
    {

        public static byte[] Encrypt(byte[] code, byte[] key)
        {
            byte[] output = new byte[code.Length];
            long ecx = BitConverter.ToUInt32(key, 0);
            long edx = ecx;
            byte dl = 0;
            byte bl = 0;

            byte[] start3;
            int i = 0;

            foreach (byte b in code)
            {
                bl = b;

                ecx *= 0x3d09;
                edx = ecx >> 0x10;

                start3 = BitConverter.GetBytes(edx);

                dl = start3[0];

                bl += dl;

                output[i] = bl;
                i++;
            }

            return output;
        }

        public static byte[] Decrypt(byte[] code, byte[] key)
        {
            byte[] output = new byte[code.Length];
            long ecx = BitConverter.ToUInt32(key, 0);
            long edx = ecx;
            byte dl = 0;
            byte bl = 0;

            byte[] start3;
            int i = 0;

            foreach (byte b in code)
            {
                bl = b;

                ecx *= 0x3d09;
                ecx = ecx & 0xffffffff;

                edx = ecx >> 0x10;

                start3 = BitConverter.GetBytes(edx);

                dl = start3[0];

                bl -= dl;

                output[i] = bl;
                i++;
            }

            return output;
        }

    }
}