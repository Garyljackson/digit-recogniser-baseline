using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace DigitRecogniserBaseline.MNIST
{
    public static class ImageWriter
    {
        public static async Task WriteImageToFileAsync(int[,] image, string outputFilePath)
        {
            var numRows = image.GetLength(0);
            var numCols = image.GetLength(1);

            var img = new Image<Rgb24>(numCols, numRows);

            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numCols; col++)
                {
                    var value = (byte)image[row, col];
                    img[col, row] = new Rgb24(value, value, value);
                }
            }

            await using var stream = File.OpenWrite(outputFilePath);
            await img.SaveAsBmpAsync(stream);
        }
    }
}
