namespace DigitRecogniserBaseline.ConsoleApp
{
    internal class Prediction
    {
        public Prediction(int predicted, bool isAccurate )
        {
            Predicted = predicted;
            IsAccurate = isAccurate;
        }

        public int Predicted { get; set; }

        public bool IsAccurate { get; set; }
    }
}
