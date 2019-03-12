using System;
using System.Collections.Generic;
using System.Text;
using Arrowgene.Services.Buffers;
using Arrowgene.Services.Extra;

namespace Arrowgene.StepFile.Core.Asset.Ez2On.DotBin
{
    public abstract class BinFile<T>
    {
        public const int HeaderSize = 12;
        // 949 | ks_c_5601-1987 | Korean     
        public static readonly Encoding KoreanEncoding = CodePagesEncodingProvider.Instance.GetEncoding(949);

        public BinFile()
        {
            Entries = new List<T>();
        }

        public abstract string Header { get; }
        public List<T> Entries { get; }

        public abstract T ReadEntry(IBuffer buffer);

        public abstract void WriteEntry(T entry, IBuffer buffer);

        public void Read(string path)
        {
            byte[] dataBin = Utils.ReadFile(path);
            if (dataBin.Length < HeaderSize)
            {
                throw new Exception("Invalid file size.");
            }

            IBuffer buffer = new StreamBuffer(dataBin);
            buffer.SetPositionStart();
            string header = buffer.ReadString(Header.Length);
            if (header != Header)
            {
                throw new Exception("Invalid header.");
            }

            buffer.Position = HeaderSize;
            int itemCount = buffer.ReadInt32();
            for (int i = 0; i < itemCount; i++)
            {
                T entry = ReadEntry(buffer);
                Entries.Add(entry);
            }
        }

        public void Write(string path)
        {
            IBuffer buffer = new StreamBuffer();
            buffer.WriteString(Header);
            buffer.Position = HeaderSize;
            buffer.WriteInt32(Entries.Count);
            for (int i = 1; i < Entries.Count; i++)
            {
                T entry = Entries[i];
                WriteEntry(entry, buffer);
            }

            Utils.WriteFile(buffer.GetAllBytes(), path);
        }

        protected string ReadString(IBuffer buffer)
        {
            int count = buffer.ReadInt32();
            string base64 = buffer.ReadString(count);
            byte[] base64Bytes = Convert.FromBase64String(base64);
            string decodedString = KoreanEncoding.GetString(base64Bytes);
            return decodedString;
        }

        protected void WriteString(string decodedString, IBuffer buffer)
        {
            byte[] base64Bytes = KoreanEncoding.GetBytes(decodedString);
            string base64 = Convert.ToBase64String(base64Bytes);
            buffer.WriteInt32(base64.Length);
            buffer.WriteString(base64);
        }
    }
}