using System;

namespace Arrowgene.StepFile.Core.Asset.Ez2On.Model
{
    [Serializable]
    public class Song
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Id { get; set; }
        public int Bpm { get; set; }
        public int RubyEzExr { get; set; }
        public int RubyEzNotes { get; set; }
        public int RubyShdExr { get; set; }
        public int RubyShdNotes { get; set; }
        public int ClubHdExr { get; set; }
        public int ClubHdNotes { get; set; }
        public int ClubShdNotes { get; set; }
        public SongCategoryType Category { get; set; }
        public string FileName { get; set; }
        public int d2 { get; set; }
        public int d1 { get; set; }
        public int d4 { get; set; }
        public int d6 { get; set; }
        public int d7 { get; set; }
        public int RubyNmExr { get; set; }
        public int d9 { get; set; }
        public int RubyNmNotes { get; set; }
        public int d11 { get; set; }
        public int d12 { get; set; }
        public int RubyHdExr { get; set; }
        public int d14 { get; set; }
        public int RubyHdNotes { get; set; }
        public int d16 { get; set; }
        public int d17 { get; set; }
        public int d19 { get; set; }
        public int d21 { get; set; }
        public int d22 { get; set; }
        public int StreetEzExr { get; set; }
        public int d24 { get; set; }
        public int StreetEzNotes { get; set; }
        public int d26 { get; set; }
        public int d27 { get; set; }
        public int StreetNmExr { get; set; }
        public int d29 { get; set; }
        public int StreetNmNotes { get; set; }
        public int d31 { get; set; }
        public int d32 { get; set; }
        public int d52 { get; set; }
        public int d51 { get; set; }
        public int ClubNmNotes { get; set; }
        public int d49 { get; set; }
        public int ClubNmExr { get; set; }
        public int d47 { get; set; }
        public int d46 { get; set; }
        public int ClubEzNotes { get; set; }
        public int d44 { get; set; }
        public int StreetHdExr { get; set; }
        public int d34 { get; set; }
        public int StreetHdNotes { get; set; }
        public int d36 { get; set; }
        public int d37 { get; set; }
        public int StreetShdExr { get; set; }
        public int d39 { get; set; }
        public int StreetShdNotes { get; set; }
        public int d41 { get; set; }
        public int d42 { get; set; }
        public int ClubEzExr { get; set; }
        public int ClubShdExr { get; set; }
        public int d59 { get; set; }
        public int d57 { get; set; }
        public int d56 { get; set; }
        public int d54 { get; set; }
        public int d61 { get; set; }
        public float MeasureScale { get; set; }
        public byte JudgmentKool  { get; set; }
        public byte JudgmentCool { get; set; }
        public byte JudgmentGood  { get; set; }
        public byte JudgmentMiss  { get; set; }
        public float GaugeCool { get; set; }
        public float GaugeGood { get; set; }
        public float GaugeMiss { get; set; }
        public float GaugeFail { get; set; }

        public int GetExr(ModeType mode, DifficultyType difficulty)
        {
            switch (mode)
            {
                case ModeType.RubyMix: return GetRubyExr(difficulty);
                case ModeType.StreetMix: return GetStreetExr(difficulty);
                case ModeType.ClubMix: return GetClubExr(difficulty);
            }
            return -1;
        }

        public int GetRubyExr(DifficultyType difficulty)
        {
            switch (difficulty)
            {
                case DifficultyType.EZ: return RubyEzExr;
                case DifficultyType.NM: return RubyNmExr;
                case DifficultyType.HD: return RubyHdExr;
                case DifficultyType.SHD: return RubyShdExr;
            }
            return -1;
        }

        public int GetStreetExr(DifficultyType difficulty)
        {
            switch (difficulty)
            {
                case DifficultyType.EZ: return StreetEzExr;
                case DifficultyType.NM: return StreetNmExr;
                case DifficultyType.HD: return StreetHdExr;
                case DifficultyType.SHD: return StreetShdExr;
            }
            return -1;
        }

        public int GetClubExr(DifficultyType difficulty)
        {
            switch (difficulty)
            {
                case DifficultyType.EZ: return ClubEzExr;
                case DifficultyType.NM: return ClubNmExr;
                case DifficultyType.HD: return ClubHdExr;
                case DifficultyType.SHD: return ClubShdExr;
            }
            return -1;
        }
    }
}