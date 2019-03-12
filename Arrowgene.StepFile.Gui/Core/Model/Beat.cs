namespace Arrowgene.StepFile.Core.Model
{
    public class Beat
    {

        public Beat()
        {

        }

        public Beat(float number, float value)
        {
            this.Number = number;
            this.Value = value;
        }

        public float Number { get; set; }
        public float Value { get; set; }



    }
}
