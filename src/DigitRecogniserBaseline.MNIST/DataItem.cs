namespace DigitRecogniserBaseline.MNIST
{
    public class DataItem
    {
        public DataItem(int label, int[,] image)
        {
            Label = label;
            Image = image;
        }

        public int Label { get; set; }
        public int[,] Image { get; set; }
    }
}
