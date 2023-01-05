namespace DigitRecogniserBaseline.MNIST
{
    public class DataSet
    {
        public DataSet(List<DataItem> trainingData, List<DataItem> testingData)
        {
            TrainingData = trainingData;
            TestingData = testingData;
        }

        public List<DataItem> TrainingData { get; set; }
        public List<DataItem> TestingData { get; set; }
    }
}
