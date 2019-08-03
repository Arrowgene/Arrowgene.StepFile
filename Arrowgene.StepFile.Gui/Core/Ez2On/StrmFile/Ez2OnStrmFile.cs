using System;
using Arrowgene.Services.Buffers;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.StrmFile
{
    public class Ez2OnStrmFile
    {
        public const int HeaderSize = 12;
        public string Header => "STRM 1.0.0.0 ";

        public Ez2OnStrmFile()
        {
   
        }

        public void Read(IBuffer buffer)
        {
            if (buffer.Size < Ez2OnStrmFile.HeaderSize)
            {
                throw new Exception("Invalid file size.");
            }
            buffer.SetPositionStart();
            string header = buffer.ReadString(Header.Length);
            if (header != Header)
            {
                throw new Exception("Invalid header.");
            }
            buffer.Position = Ez2OnStrmFile.HeaderSize;
            int itemCount = buffer.ReadInt32();
        }

        public void Write(IBuffer buffer)
        {
            buffer.WriteString(Header);
            buffer.Position = Ez2OnStrmFile.HeaderSize;

        }
    }
}