namespace DigitRecogniserBaseline.MNIST
{
    public class DataItem
    {
        public DataItem(int label, double[,] image)
        {
            Label = label;
            Image = image;
        }

        public int Label { get; set; }
        public double[,] Image { get; set; }
    }
}
