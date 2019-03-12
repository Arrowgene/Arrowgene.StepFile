
using Arrowgene.Services.Buffers;
using Arrowgene.StepFile.Core.Model;

namespace Arrowgene.StepFile.Core.Format.Sdo
{
    public class SdoWriter : IStepFileWriter
    {
        public void Write(StpFile stepFile, string destinationPath)
        {
            IBuffer buffer = new StreamBuffer();

            int id = buffer.ReadInt32();
            string type = buffer.ReadString(4);

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            int levelEasy = buffer.ReadInt16();
            int levelMedium = buffer.ReadInt16();
            int levelHard = buffer.ReadInt16();

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            buffer.ReadInt16();

            int notesCountEasy = buffer.ReadInt32();
            int notesCountMedium = buffer.ReadInt32();
            int notesCountHard = buffer.ReadInt32();

            int measurementsEasy = buffer.ReadInt32();
            int measurementsMedium = buffer.ReadInt32();
            int measurementsHard = buffer.ReadInt32();

            buffer.ReadInt32();
            buffer.ReadInt32();
            buffer.ReadInt32();

            buffer.ReadString(32);
            string title = buffer.ReadString(32);
            buffer.ReadString(32);
            string writer = buffer.ReadString(32);
            string producer = buffer.ReadString(32);
            string fileName = buffer.ReadString(32);

            buffer.ReadInt32();

            int durationEasy = buffer.ReadInt32();
            int durationMedium = buffer.ReadInt32();
            int durationHard = buffer.ReadInt32();

            int addressEasy = buffer.ReadInt32();
            int addressMedium = buffer.ReadInt32();
            int addressHard = buffer.ReadInt32();
            int addressFileEnd = buffer.ReadInt32();

            for (int j = 0; j < measurementsEasy; j++)
            {

                int measurement = buffer.ReadInt32();
                int frame = buffer.ReadInt16();
                int noteIntervall = buffer.ReadInt16();

                for (int i = 0; i < noteIntervall; i++)
                {
                    int line = buffer.ReadInt32();
                }

            }
        }
    }
}