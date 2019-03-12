namespace Arrowgene.StepFile.Core.Format.Sim
{
    using Arrowgene.StepFile.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class SimFileWriter : IStepFileWriter
    {
        private const int LINE_FEED = 10;
        private const int CARRIAGE_RETURN = 13;

        public SimFileWriter()
        {
            // TODO
            // Pretty Format
        }

        public void Write(StpFile stepFile, string destinationPath)
        {
            if (stepFile.IsValid())
            {
                using (FileStream fileStream = new FileStream(destinationPath, FileMode.CreateNew, FileAccess.Write))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.UTF8))
                    {
                        this.WriteProperty("TITLE", stepFile.Title, binaryWriter);
                        this.WriteProperty("SUBTITLE", "", binaryWriter);
                        this.WriteProperty("ARTIST", stepFile.Artist, binaryWriter);
                        this.WriteProperty("TITLETRANSLIT", "", binaryWriter);
                        this.WriteProperty("SUBTITLETRANSLIT", "", binaryWriter);
                        this.WriteProperty("ARTISTTRANSLIT", "", binaryWriter);
                        this.WriteProperty("GENRE", "", binaryWriter);
                        this.WriteProperty("CREDIT", "", binaryWriter);
                        this.WriteProperty("BANNER", "", binaryWriter);
                        this.WriteProperty("BACKGROUND", "", binaryWriter);
                        this.WriteProperty("LYRICSPATH", "", binaryWriter);
                        this.WriteProperty("CDTITLE", "", binaryWriter);
                        this.WriteProperty("MUSIC", "", binaryWriter);
                        this.WriteProperty("OFFSET", "", binaryWriter);
                        this.WriteProperty("BPMS", this.WriteTimings(stepFile.BPMs), binaryWriter);
                        this.WriteProperty("STOPS", this.WriteTimings(stepFile.Stops), binaryWriter);
                        this.WriteProperty("SAMPLESTART", "", binaryWriter);
                        this.WriteProperty("SAMPLELENGTH", "", binaryWriter);
                        this.WriteProperty("DISPLAYBPM", "", binaryWriter);
                        this.WriteProperty("SELECTABLE", "", binaryWriter);
                        this.WriteProperty("BGCHANGES", "", binaryWriter);
                        this.WriteProperty("FGCHANGES", "", binaryWriter);
                        this.WriteNotes(stepFile, binaryWriter);
                    }
                }
            }
            else
            {
                // not valid
            }
        }

        private void WriteNotes(StpFile stepFile, BinaryWriter binaryWriter)
        {
            foreach (Difficulty difficulty in stepFile.Difficulties)
            {
                this.WriteString("#NOTES:", binaryWriter);
                this.WriteNewLine(binaryWriter);

                // ChartType
                string chartType = string.Empty;
                switch (difficulty.ChartType)
                {
                    case ChartType.FourKey: chartType = "dance-single"; break;
                    case ChartType.FiveKey: chartType = "pump-single"; break;
                    case ChartType.SixKey: chartType = "dance-solo"; break;
                    case ChartType.SevenKey: chartType = "kb7-single"; break;
                    case ChartType.EightKey: chartType = "dance-double"; break;
                    case ChartType.TenKey: chartType = "pump-double"; break;
                }
                this.WriteString(string.Format("{0}:", chartType), binaryWriter);
                this.WriteNewLine(binaryWriter);

                // Description
                this.WriteString(string.Format("{0}:", "description"), binaryWriter);
                this.WriteNewLine(binaryWriter);

                // Difficulty (string)
                this.WriteString(string.Format("{0}:", ""), binaryWriter);
                this.WriteNewLine(binaryWriter);

                // Numeric Difficulty (int)
                this.WriteString(string.Format("{0}:", difficulty.Level), binaryWriter);
                this.WriteNewLine(binaryWriter);

                //Groove Radar (CSV-List)
                this.WriteString(string.Format("{0}:", ""), binaryWriter);
                this.WriteNewLine(binaryWriter);

                int currentMeasureIndex = 0;

                difficulty.Measures.Sort((x, y) => y.Index.CompareTo(x.Index));
                foreach (Measure measure in difficulty.Measures)
                {
                    measure.Lines.Sort((x, y) => y.Index.CompareTo(x.Index));
                    foreach (Line line in measure.Lines)
                    {
                        line.Steps.Sort((x, y) => y.Index.CompareTo(x.Index));
                        foreach (Step step in line.Steps)
                        {
                            char stepType = '0';
                            switch (step.StepType)
                            {
                                case StepType.Normal: stepType = '1'; break;
                                case StepType.HoldStart: stepType = '2'; break;
                                case StepType.HoldEnd: stepType = '3'; break;
                                case StepType.RollStart: stepType = '4'; break;
                                case StepType.Mine: stepType = 'M'; break;
                                default:
                                case StepType.None: stepType = '0'; break;
                            }
                            binaryWriter.Write((byte)stepType);
                        }
                        this.WriteNewLine(binaryWriter);
                    }

                    currentMeasureIndex++;

                    if (difficulty.Measures.Count == currentMeasureIndex)
                    {
                        binaryWriter.Write((byte)';');
                    }
                    else
                    {
                        binaryWriter.Write((byte)',');
                    }

                    this.WriteNewLine(binaryWriter);
                }
            }
        }

        private string WriteTimings(List<Beat> timings)
        {
            string result = string.Empty;

            if (timings.Count > 0)
            {
                int count = timings.Count;

                string[] values = new string[count];

                for (int i = 0; i < count; i++)
                {
                    string value = string.Format(CultureInfo.InvariantCulture, "{0}={1}", timings[i].Number, timings[i].Value);
                    values[i] = value;
                }

                result = string.Join(",", values);
            }

            return result;
        }

        private void WriteProperty(string key, string value, BinaryWriter binaryWriter)
        {
            string property = string.Format("#{0}:{1};", key, value);
            this.WriteString(property, binaryWriter);
            this.WriteNewLine(binaryWriter);
        }

        private void WriteString(string s, BinaryWriter binaryWriter)
        {
            for (int i = 0; i < s.Length; i++)
            {
                binaryWriter.Write((byte)s[i]);
            }
        }

        private void WriteNewLine(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((byte)CARRIAGE_RETURN);
            binaryWriter.Write((byte)LINE_FEED);
        }

    }
}