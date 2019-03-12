namespace Arrowgene.StepFile.Core.Ez2On.Archive
{
    public class Ez2OnArchiveFile 
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DirectoryPath { get; set; }
        public string FullPath { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public bool Encrypted { get; set; }
        public byte[] Data { get; set; }
    }
}
