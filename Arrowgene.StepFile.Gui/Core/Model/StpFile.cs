namespace Arrowgene.StepFile.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for all the data within a step file. Step files contain multiple difficulties,
    /// each can be of a different game mode.
    /// </summary>
    public class StpFile
    {
        public StpFile()
        {
            this.Difficulties = new List<Difficulty>();
            this.Artist = string.Empty;
            this.BPMs = new List<Beat>();
            this.Stops = new List<Beat>();
            this.Credit = string.Empty;
            this.Genre = string.Empty;
            this.Offset = string.Empty;
            this.SampleStart = string.Empty;
            this.Title = string.Empty;
            this.Logs = new List<string>();
            this.Comments = new List<string>();
        }

        public string Artist { get; set; }
        public List<Beat> BPMs { get; set; }
        public List<Beat> Stops { get; set; }
        public string Credit { get; set; }
        public string Genre { get; set; }
        public string Offset { get; set; }
        public string SampleStart { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string FileExtension { get; set; }
        public string Producer { get; set; }
        public string FileName { get; set; }

        public List<Difficulty> Difficulties { get; set; }

        /// <summary>
        /// Comments inside File
        /// </summary>
        public List<string> Comments { get; set; }

        /// <summary>
        /// Logged events while working with this object
        /// </summary>
        public List<string> Logs { get; set; }

        /// <summary>
        /// Validate the Stepfile.
        /// </summary>
        public bool IsValid()
        {
            bool isValid = true;


            if (string.IsNullOrEmpty(this.Title))
            {
                isValid = false;
                this.Logs.Add("missing title");
            }

            if(this.Difficulties.Count <= 0)
            {
                isValid = false;
                this.Logs.Add("missing difficulties");
            }

            foreach (Difficulty difficulty in this.Difficulties)
            {
                if (!difficulty.IsValid())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
