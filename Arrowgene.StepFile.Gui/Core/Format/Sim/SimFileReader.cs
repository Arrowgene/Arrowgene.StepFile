namespace Arrowgene.StepFile.Core.Format.Sim
{
    using Arrowgene.StepFile.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class SimFileReader : IStepFileReader
    {
        private const int HASHTAG = 35;
        private const int COLON = 58;
        private const int SEMICOLON = 59;
        private const int TABULATOR = 9;
        private const int LINE_FEED = 10;
        private const int CARRIAGE_RETURN = 13;
        private const int SPACE = 32;
        private const int SLASH = 47;

        private const string NOTE_KEY = "NOTES";

        public SimFileReader()
        {
            // TODO:
            // Detect Comments through whole file (currently only in notes section)
            // Have a Comments list on each Object
            // Dont read "emty" notes
        }

        public StpFile Read(byte[] file)
        {
            // A .sm file is primarily composed of two major sections: the header, and the chart data. 
            // The .sm file format is mostly a key/value store, though the actual note and chart data is a bit more complex.

            StpFile stepFile = new StpFile();
            Dictionary<string, string> simFileMetaEntries = new Dictionary<string, string>();
            List<string> simNoteEntries = new List<string>();

            if (file != null)
            {
                using (MemoryStream stream = new MemoryStream(file))
                {
                    int symbol;
                    while ((symbol = stream.ReadByte()) >= 0)
                    {
                        if (symbol == HASHTAG)
                        {
                            string key = this.ReadTillChar(stream, COLON);
                            string value = this.ReadTillChar(stream, SEMICOLON);
                            if (key == NOTE_KEY)
                            {
                                simNoteEntries.Add(value);
                            }
                            else
                            {
                                simFileMetaEntries.Add(key, value);
                            }
                        }
                    }
                }

                this.ParseMeta(simFileMetaEntries, stepFile);
                this.ParseNotes(simNoteEntries, stepFile);
            }

            return stepFile;
        }

        private string ReadTillChar(MemoryStream stream, int character)
        {
            string readCharacters = string.Empty;
            int symbol;
            while ((symbol = stream.ReadByte()) >= 0 && symbol != character)
            {
                readCharacters += (char)symbol;
            }
            return readCharacters;
        }

        private List<Beat> ReadTimings(string values)
        {
            List<Beat> timings = new List<Beat>();

            foreach (string timing in values.Split(','))
            {
                string[] keyValue = timing.Split('=');

                if (keyValue.Length > 1)
                {
                    float beatNumber;
                    float beatValue;

                    if (float.TryParse(keyValue[0], NumberStyles.Float, CultureInfo.InvariantCulture, out beatNumber)
                        && float.TryParse(keyValue[1], NumberStyles.Float, CultureInfo.InvariantCulture, out beatValue))
                    {
                        Beat beat = new Beat(beatNumber, beatValue);
                        timings.Add(beat);
                    }
                }
            }

            return timings;
        }

        private void ParseMeta(Dictionary<string, string> simFileMetaEntries, StpFile stepFile)
        {
            // Header Tags
            // The header tags are song - specific and are shared between all charts. Most header tags follow the format #TAG:VALUE;, though some tags have their own format.

            // Sets the primary title of the song.
            if (simFileMetaEntries.ContainsKey("TITLE"))
            {
                stepFile.Title = simFileMetaEntries["TITLE"];
            }

            // Sets the subtitle of the song.
            if (simFileMetaEntries.ContainsKey("SUBTITLE"))
            {
            }

            // Sets the artist of the song.
            if (simFileMetaEntries.ContainsKey("ARTIST"))
            {
                stepFile.Artist = simFileMetaEntries["ARTIST"];
            }

            // Sets the transliterated primary title of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("TITLETRANSLIT"))
            {
            }

            // Sets the transliterated subtitle of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("SUBTITLETRANSLIT"))
            {
            }

            // Sets the transliterated artist of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("ARTISTTRANSLIT"))
            {
            }

            // Sets the genre of the song.
            if (simFileMetaEntries.ContainsKey("GENRE"))
            {
                stepFile.Genre = simFileMetaEntries["GENRE"];
            }

            // Define's the simfile's origin (author or pack/mix).
            if (simFileMetaEntries.ContainsKey("CREDIT"))
            {
                stepFile.Credit = simFileMetaEntries["CREDIT"];
            }

            // Sets the path to the banner image for the song. Banner images are typically rectangular, with common sizes being 256x80(DDR), 418x164(ITG), and 512x160(2x DDR).
            if (simFileMetaEntries.ContainsKey("BANNER"))
            {
            }

            // Sets the path to the background image for the song. Background images are typically 640x480 or greater in resolution.
            if (simFileMetaEntries.ContainsKey("BACKGROUND"))
            {
            }

            // Sets the path to the lyrics file to use. (todo: explain.lrc format ?)
            if (simFileMetaEntries.ContainsKey("LYRICSPATH"))
            {
            }

            // Sets the path to the CD Title, a small image meant to show the origin of the song.The recommended size is around 64x48, though a number of people ignore this and make big stupid ones for some dumb reason.
            if (simFileMetaEntries.ContainsKey("CDTITLE"))
            {
            }

            // Sets the path to the music file for this song.
            if (simFileMetaEntries.ContainsKey("MUSIC"))
            {
            }

            // Sets the offset between the beginning of the song and the beginning of the notes.
            if (simFileMetaEntries.ContainsKey("OFFSET"))
            {
                stepFile.Offset = simFileMetaEntries["OFFSET"];
            }

            // Sets the BPMs for this song. BPMS are defined in the format Beat=BPM, with each value separated by a comma.
            // BPM: Beats per minute, or a measure of how fast the song is.
            if (simFileMetaEntries.ContainsKey("BPMS"))
            {
                stepFile.BPMs = this.ReadTimings(simFileMetaEntries["BPMS"]);
            }

            // Sets the stops for this song. Stops are defined in the format Beat=Seconds, with each value separated by a comma.
            // Stop: A pause in the chart that lasts a certain number of milliseconds.
            if (simFileMetaEntries.ContainsKey("STOPS"))
            {
                stepFile.Stops = this.ReadTimings(simFileMetaEntries["STOPS"]);
            }

            // Sets the start time of the song sample used on ScreenSelectMusic.
            if (simFileMetaEntries.ContainsKey("SAMPLESTART"))
            {
                stepFile.SampleStart = simFileMetaEntries["SAMPLESTART"];
            }

            // Sets the length of the song sample used on ScreenSelectMusic.
            if (simFileMetaEntries.ContainsKey("SAMPLELENGTH"))
            {
            }

            // This can be used to override the BPM shown on ScreenSelectMusic.This tag supports three types of values:
            // A number by itself(e.g. #DISPLAYBPM:180;) will show a static BPM.
            // Two numbers in a range(e.g. #DISPLAYBPM:90-270;) will show a BPM that changes between two values.
            // An asterisk(#DISPLAYBPM:*;) will show a BPM that randomly changes.
            if (simFileMetaEntries.ContainsKey("DISPLAYBPM"))
            {
            }

            // Determines if the song is selectable under normal conditions.
            // Valid values are YES and NO.
            if (simFileMetaEntries.ContainsKey("SELECTABLE"))
            {
            }

            // Defines the background changes for this song. 
            // The format for each change is as follows: Beat = BGAnim =? float =? int =? int =? int.
            if (simFileMetaEntries.ContainsKey("BGCHANGES"))
            {
            }

            // Defines the foreground changes for this song. 
            // Format is the same as #BGCHANGES.
            if (simFileMetaEntries.ContainsKey("FGCHANGES"))
            {
            }
        }

        private void ParseNotes(List<string> simNoteEntries, StpFile stepFile)
        {
            const int metaEntries = 5;

            foreach (string simNoteEntry in simNoteEntries)
            {
                Difficulty stepFileDifficulty = new Difficulty(stepFile);

                ChartType chartType = ChartType.None;
                string description = String.Empty;
                string difficulty = String.Empty;
                int numericMeter = 0;
                string grooveRadar;

                using (StringReader stringReader = new StringReader(simNoteEntry))
                {
                    int symbol;

                    // Parse notes tags
                    int index = 0;
                    string value = String.Empty;

                    while ((symbol = stringReader.Read()) >= 0 && index < metaEntries)
                    {
                        // The Notes tag contains the following information:
                        //
                        // [0] Chart type (e.g.dance - single)
                        // [1] Description / author
                        // [2] Difficulty(one of Beginner, Easy, Medium, Hard, Challenge, Edit)
                        // [3] Numerical meter
                        // [4] Groove radar values, generated by the program
                        //
                        // The first five values are postfixed with a colon.
                        // Groove radar values are separated with commas.

                        if (symbol != COLON)
                        {
                            if (symbol != LINE_FEED
                                && symbol != CARRIAGE_RETURN
                                && symbol != SPACE)
                            {
                                value += (char)symbol;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 0:
                                    if (value == "dance-single")
                                    {
                                        chartType = ChartType.FourKey;
                                    }
                                    else if (value == "pump-single")
                                    {
                                        chartType = ChartType.FiveKey;
                                    }
                                    else if (value == "dance-solo")
                                    {
                                        chartType = ChartType.SixKey;
                                    }
                                    else if (value == "kb7-single")
                                    {
                                        chartType = ChartType.SevenKey;
                                    }
                                    else if (value == "dance-double")
                                    {
                                        chartType = ChartType.EightKey;
                                    }
                                    else if (value == "pump-double")
                                    {
                                        chartType = ChartType.TenKey;
                                    }
                                    break;
                                case 1: description = value; break;
                                case 2: difficulty = value; break;
                                case 3: int.TryParse(value, out numericMeter); break;
                                case 4: grooveRadar = value; break;
                            }

                            value = string.Empty;
                            index++;
                        }
                    }

                    if (chartType != ChartType.None)
                    {
                        stepFileDifficulty.ChartType = chartType;
                        stepFileDifficulty.Level = numericMeter;

                        // Parse notes
                        int slashCount = 0;
                        value = string.Empty;

                        while ((symbol = stringReader.Read()) >= 0)
                        {
                            if (symbol == SLASH)
                            {
                                slashCount++;
                                continue;
                            }

                            if (slashCount > 1)
                            {
                                // comment, eat until \r or \n is encountered
                                if (symbol != LINE_FEED || symbol != CARRIAGE_RETURN)
                                {
                                    continue;
                                }

                                slashCount = 0;
                            }

                            if (symbol != LINE_FEED
                                && symbol != CARRIAGE_RETURN
                                && symbol != SPACE
                                && symbol != TABULATOR)
                            {
                                value += (char)symbol;
                            }
                        }

                        string[] measurements = value.Split(',');
                        int measureRowIndex = 0;

                        foreach (string measureRow in measurements)
                        {
                            // Note data itself is a bit more complex; 
                            // there's one character for every possible playable column in a chart type. 
                            // Note types (e.g. 4th, 8th, etc.) are determined by how many rows exist before the comma (which separates measures).

                            int notesPerLine = (int)chartType;
                            int lineCount = measureRow.Length / notesPerLine;

                            Measure measure = new Measure(stepFile);
                            measure.Index = measureRowIndex;

                            for (int currentLineCount = 0; currentLineCount < lineCount; currentLineCount++)
                            {
                                Line line = new Line(stepFile);
                                line.Index = currentLineCount;

                                int noteStartIndex = currentLineCount * notesPerLine;

                                for (int currentNoteInLine = 0; currentNoteInLine < notesPerLine; currentNoteInLine++)
                                {
                                    Step step = new Step(stepFile);
                                    step.Index = currentNoteInLine;

                                    int currentNoteIndex = noteStartIndex + currentNoteInLine;

                                    switch (measureRow[currentNoteIndex])
                                    {
                                        // Note Values
                                        // These are the standard note values:
                                        //
                                        // 0 – No note
                                        // 1 – Normal note
                                        // 2 – Hold head
                                        // 3 – Hold / Roll tail
                                        // 4 – Roll head
                                        // M – Mine
                                        // Later versions of StepMania accept other note values which may not work in older versions:
                                        //
                                        // K – Automatic keysound
                                        // L – Lift note
                                        // F – Fake note
                                        // Non - Standard Tags
                                        // You might run into some .sm files with some non - standard tags.Though these aren't supported by StepMania, they're good to know.

                                        case '0': step.StepType = StepType.None; break;
                                        case '1': step.StepType = StepType.Normal; break;
                                        case '2': step.StepType = StepType.HoldStart; break;
                                        case '3': step.StepType = StepType.HoldEnd; break;
                                        case '4': step.StepType = StepType.RollStart; break;
                                        case 'M': step.StepType = StepType.Mine; break;
                                        case 'K': break;
                                        case 'L': break;
                                        case 'F': break;
                                    }
                                    line.Steps.Add(step);
                                }
                                measure.Lines.Add(line);
                            }
                            stepFileDifficulty.Measures.Add(measure);
                            measureRowIndex++;
                        }

                    }
                    else
                    {
                        // invalid chart type
                    }
                }
                stepFile.Difficulties.Add(stepFileDifficulty);
            }
        }
    }
}