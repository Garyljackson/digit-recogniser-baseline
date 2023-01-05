namespace DigitRecogniserBaseline.MNIST
{
    public static class DataReader
    {
        public static async Task<DataSet> ReadDataAsync()
        {
            await ArchiveExtractor.ExtractAll();
            var trainingData = await DataParser.GetTrainingDataAsync();
            var testData = await DataParser.GetTestDataAsync();

            return new DataSet(trainingData, testData);
        }
    }
}
