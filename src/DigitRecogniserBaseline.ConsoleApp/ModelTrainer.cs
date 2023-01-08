using DigitRecogniserBaseline.MNIST;

namespace DigitRecogniserBaseline.ConsoleApp
{
    internal static class ModelTrainer
    {
        internal static List<DataItem> Train(DataSet dataSet)
        {
            var groupedTrainingData = dataSet.TrainingData.GroupBy(item => item.Label);
            var averagedItems = new List<DataItem>();

            foreach (var grouping in groupedTrainingData)
            {
                var numRows = grouping.First().Image.GetLength(0);
                var numCols = grouping.First().Image.GetLength(1);

                var averagedImage = new int[numRows, numCols];

                var totalDigits = grouping.Count();

                foreach (var dataItem in grouping)
                {
                    for (var row = 0; row < numRows; row++)
                    {
                        for (var col = 0; col < numCols; col++)
                        {
                            var value = dataItem.Image[row, col];
                            averagedImage[row, col] += value;
                        }
                    }
                }

                for (var row = 0; row < averagedImage.GetLength(0); row++)
                {
                    for (var col = 0; col < averagedImage.GetLength(1); col++)
                    {
                        averagedImage[row, col] /= totalDigits;
                    }
                }

                averagedItems.Add(new DataItem(grouping.Key, averagedImage));
            }

            return averagedItems;
        }
    }
}
