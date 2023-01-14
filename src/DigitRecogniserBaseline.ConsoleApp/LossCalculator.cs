using DigitRecogniserBaseline.MNIST;

namespace DigitRecogniserBaseline.ConsoleApp
{
    internal static class LossCalculator
    {

        public static double CalculateLoss(DataItem idealDigit, DataItem comparisonDigit)
        {
            var loss = CalculateRootMeanSquaredError(idealDigit, comparisonDigit);

            // Generally when images are floats, the pixel values are expected to be between 0 and 1, so we will also divide by 255 here
            return loss / 255;
        }

        private static double CalculateRootMeanSquaredError(DataItem idealDigit, DataItem comparisonDigit)
        {
            var numRows = idealDigit.Image.GetLength(0);
            var numCols = idealDigit.Image.GetLength(1);

            double sumSquaredDifferences = 0;
            var count = 0;

            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numCols; col++)
                {
                    var difference = comparisonDigit.Image[row, col] - idealDigit.Image[row, col];
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
