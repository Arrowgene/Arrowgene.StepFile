namespace Arrowgene.StepFile.Core.Model
{
    public enum StepType
    {
        None = 0,
        Normal = 1,
        /// <summary> A segment in which you must continually hold the corresponding button to keep it alive, so you can score it</summary>
        HoldStart = 2,
        HoldEnd = 3,
        /// <summary> A segment in which you must continually press the corresponding button to keep it alive, so you can score it</summary>
        RollStart = 4,
        Mine = 5
    }

    public enum ChartType
    {
        None = 0,
        FourKey = 4,
        FiveKey = 5,
        SixKey = 6,
        SevenKey = 7,
        EightKey = 8,
        TenKey = 10
    }
}
