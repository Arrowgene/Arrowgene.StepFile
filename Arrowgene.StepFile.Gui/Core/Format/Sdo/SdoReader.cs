namespace Arrowgene.StepFile.Core.Format.Sdo
{
    using System;
    using Model;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Arrowgene.Services.Buffers;

    public class SdoReader : IStepFileReader
    {
        public const int NOTES_PER_LINE = 4;

        public enum FrameType
        {
            None = -1,
            Left = 2,
            Up = 4,
            Down = 3,
            Right = 5
        }

        public enum NoteType
        {
            None = -1,
            Arrow = 0,
            HoldStart = 2,
            HoldEnd = 3
        }

        public StpFile Read(byte[] file)
        {
            StpFile stepFile = new StpFile();
            Difficulty difficultyEasy = new Difficulty(stepFile);
            Difficulty difficultyMedium = new Difficulty(stepFile);
            Difficulty difficultyHard = new Difficulty(stepFile);

            IBuffer buffer = new StreamBuffer(file);

            stepFile.Id = buffer.ReadInt32();
            stepFile.FileExtension = buffer.ReadString(4);

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            buffer.ReadInt16();
            buffer.ReadInt16();
            buffer.ReadInt16();

            difficultyEasy.Level = buffer.ReadInt16();
            difficultyMedium.Level = buffer.ReadInt16();
            difficultyHard.Level = buffer.ReadInt16();

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
            stepFile.Title = buffer.ReadString(32);
            buffer.ReadString(32);
            stepFile.Artist = buffer.ReadString(32);
            stepFile.Producer = buffer.ReadString(32);
            stepFile.FileName = buffer.ReadString(32);

            buffer.ReadInt32();

            difficultyEasy.Duration = buffer.ReadInt32();
            difficultyMedium.Duration = buffer.ReadInt32();
            difficultyHard.Duration = buffer.ReadInt32();

            int addressEasy = buffer.ReadInt32();
            int addressMedium = buffer.ReadInt32();
            int addressHard = buffer.ReadInt32();
            int addressFileEnd = buffer.ReadInt32();

            difficultyEasy.Measures = this.ReadMeasurements(stepFile, buffer, measurementsEasy);
            difficultyMedium.Measures = this.ReadMeasurements(stepFile, buffer, measurementsMedium);
            difficultyHard.Measures = this.ReadMeasurements(stepFile, buffer, measurementsHard);

            stepFile.Difficulties.Add(difficultyEasy);
            stepFile.Difficulties.Add(difficultyMedium);
            stepFile.Difficulties.Add(difficultyHard);

            return stepFile;
        }

        private List<Measure> ReadMeasurements(StpFile stepFile, IBuffer buffer, int measurementsCount)
        {
            Dictionary<int, Measure> measurements = new Dictionary<int, Measure>();

            for (int j = 0; j < measurementsCount; j++)
            {
                int measureIndex = buffer.ReadInt32();
                Measure measure;

                if (measurements.ContainsKey(measureIndex))
                {
                    measure = measurements[measureIndex];
                }
                else
                {
                    measure = new Measure(stepFile);
                    measure.Index = measureIndex;
                    measurements.Add(measureIndex, measure);
                }


                int frame = buffer.ReadInt16();
                FrameType frameType = FrameType.None;
                if (Enum.IsDefined(typeof(FrameType), frame))
                {
                    frameType = (FrameType)frame;
                }

                int noteIntervall = buffer.ReadInt16();

                for (int i = 0; i < noteIntervall; i++)
                {
                    int unknown = buffer.ReadInt16();
                    buffer.ReadByte();

                    StepType stepType = StepType.None;

                    int note = buffer.ReadByte();
                    if (Enum.IsDefined(typeof(NoteType), note))
                    {
                        NoteType noteType = (NoteType)note;
                        switch (noteType)
                        {
                            case NoteType.Arrow: stepType = StepType.Normal; break;
                            case NoteType.HoldStart: stepType = StepType.HoldStart; break;
                            case NoteType.HoldEnd: stepType = StepType.HoldEnd; break;
                            default:
                            case NoteType.None: stepType = StepType.None; break;
                        }
                    }


                    Line line = null;
                    foreach (Line searchLine in measure.Lines)
                    {
                        if (searchLine.Index == i)
                        {
                            line = searchLine;
                        }
                    }

                    if (line == null)
                    {
                        line = new Line(stepFile);
                        line.Index = i;
                        measure.Lines.Add(line);
                    }

                    if (unknown > 0)
                    {

                        if (stepType != StepType.None)
                        {

                            int stepIndex = -1;
                            switch (frameType)
                            {
                                case FrameType.Left: stepIndex = 0; break;
                                case FrameType.Down: stepIndex = 1; break;
                                case FrameType.Up: stepIndex = 2; break;
                                case FrameType.Right: stepIndex = 3; break;
                            }

                            if (stepIndex == -1)
                            {
                                Debug.Write("not supported");
                            }
                            else
                            {
                                Step step = null;
                                foreach (Step searchStep in line.Steps)
                                {
                                    if (searchStep.Index == stepIndex)
                                    {
                                        step = searchStep;
                                        Debug.Write("not!!!!");
                                    }
                                }

                                if (step == null)
                                {
                                    step = new Step(stepFile);
                                    step.Index = stepIndex;
                                    step.StepType = stepType;
                                    line.Steps.Add(step);
                                }
                                else
                                {
                                    Debug.Write("CANNOT");
                                }

                            }
                        }
                    }
                }


            }

            List<Measure> fillMeasures = new List<Measure>(measurements.Values);

            foreach (Measure fillMeasure in fillMeasures)
            {
                foreach (Line fillLine in fillMeasure.Lines)
                {
                    List<int> existingSteps = new List<int>();
                    foreach (Step fillStep in fillLine.Steps)
                    {
                        existingSteps.Add(fillStep.Index);
                    }

                    for (int u = 0; u < 4; u++)
                    {
                        if (!existingSteps.Contains(u))
                        {
                            Step emptyStep = new Step(stepFile);
                            emptyStep.Index = u;
                            emptyStep.StepType = StepType.None;
                            fillLine.Steps.Add(emptyStep);
                        }
                    }
                }

            }


            return fillMeasures;
        }




    }
}