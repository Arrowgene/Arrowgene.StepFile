using System;

namespace Arrowgene.StepFile.Gui.Core.Ez2On.Model
{
    [Serializable]
    public class Ez2onModelMusic
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
        public int D2 { get; set; }
        public int D1 { get; set; }
        public int D4 { get; set; }
        public int D6 { get; set; }
        public int D7 { get; set; }
        public int RubyNmExr { get; set; }
        public int D9 { get; set; }
        public int RubyNmNotes { get; set; }
        public int D11 { get; set; }
        public int D12 { get; set; }
        public int RubyHdExr { get; set; }
        public int D14 { get; set; }
        public int RubyHdNotes { get; set; }
        public int D16 { get; set; }
        public int D17 { get; set; }
        public int D19 { get; set; }
        public int D21 { get; set; }
        public int D22 { get; set; }
        public int StreetEzExr { get; set; }
        public int D24 { get; set; }
        public int StreetEzNotes { get; set; }
        public int D26 { get; set; }
        public int D27 { get; set; }
        public int StreetNmExr { get; set; }
        public int D29 { get; set; }
        public int StreetNmNotes { get; set; }
        public int D31 { get; set; }
        public int D32 { get; set; }
        public int D52 { get; set; }
        public int D51 { get; set; }
        public int ClubNmNotes { get; set; }
        public int D49 { get; set; }
        public int ClubNmExr { get; set; }
        public int D47 { get; set; }
        public int D46 { get; set; }
        public int ClubEzNotes { get; set; }
        public int D44 { get; set; }
        public int StreetHdExr { get; set; }
        public int D34 { get; set; }
        public int StreetHdNotes { get; set; }
        public int D36 { get; set; }
        public int D37 { get; set; }
        public int StreetShdExr { get; set; }
        public int D39 { get; set; }
        public int StreetShdNotes { get; set; }
        public int D41 { get; set; }
        public int D42 { get; set; }
        public int ClubEzExr { get; set; }
        public int ClubShdExr { get; set; }
        public int D59 { get; set; }
        public int D57 { get; set; }
        public int D56 { get; set; }
        public int D54 { get; set; }
        public int D61 { get; set; }
        public float MeasureScale { get; set; }
        public byte JudgmentKool  { get; set; }
        public byte JudgmentCool { get; set; }
        public byte JudgmentGood  { get; set; }
        public byte JudgmentMiss  { get; set; }
        public float GaugeCool { get; set; }
        public float GaugeGood { get; set; }
        public float GaugeMiss { get; set; }
        public float GaugeFail { get; set; }
        public int E1 { get; set; }
        public int E2 { get; set; }
        public int E3 { get; set; }
        public int E4 { get; set; }
        public int E5 { get; set; }
        public int E6 { get; set; }
        public int E7 { get; set; }
        public int E8 { get; set; }
        public int E9 { get; set; }
        public int E10 { get; set; }
        public int E11 { get; set; }
        public int E12 { get; set; }
        public int E13 { get; set; }
        public int E14 { get; set; }


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