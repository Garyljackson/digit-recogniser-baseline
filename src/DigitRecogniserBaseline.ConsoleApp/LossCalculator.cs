using DigitRecogniserBaseline.MNIST;

namespace DigitRecogniserBaseline.ConsoleApp
{
    internal static class LossCalculator
    {
        public static double CalculateRootMeanSquaredError(DataItem idealDigit, DataItem comparisonDigit)
        {
            var numRows = idealDigit.Image.GetLength(0);
            var numCols = idealDigit.Image.GetLength(1);

            double sumSquaredDifferences = 0;
            var count = 0;

            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numCols; col++)
                {
                    double difference = comparisonDigit.Image[row, col] - idealDigit.Image[row, col];
                    sumSquaredDifferences += difference * difference;
                    count++;
                }
            }

            var meanSquaredDifference = sumSquaredDifferences / count;
            var rootMeanSquaredError = Math.Sqrt(meanSquaredDifference);

            return rootMeanSquaredError;
        }

    }
}
