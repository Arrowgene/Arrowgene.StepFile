using Arrowgene.Services.Buffers;
using Arrowgene.Services.Extra;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.StrmFile
{
    public class Ez2OnStrmFileIO
    {
        public Ez2OnStrmFile Read(string source)
        {
            byte[] dataBin = Utils.ReadFile(source);
            if (dataBin.Length < Ez2OnStrmFile.HeaderSize)
            {
                return null;
            }
            IBuffer buffer = new StreamBuffer(dataBin);
            buffer.SetPositionStart();
            string header = buffer.ReadCString();
            Ez2OnStrmFile file = new Ez2OnStrmFile();
            file.Read(buffer);
            return file;
        }

        public void Wrtire(string destination, Ez2OnStrmFile strmFile)
        {
            IBuffer buffer = new StreamBuffer();
            buffer.SetPositionStart();
            strmFile.Write(buffer);
            Utils.WriteFile(buffer.GetAllBytes(), destination);
        }

    }
}
