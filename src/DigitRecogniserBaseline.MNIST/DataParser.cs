namespace DigitRecogniserBaseline.MNIST
{
    public static class DataParser
    {
        public static async Task<List<DataItem>> GetTrainingDataAsync()
        {
            return await GetDataAsync(Constants.TrainImagesExtractedFileName, Constants.TrainLabelsExtractedFileName);
        }
        
        public static async Task<List<DataItem>> GetTestDataAsync()
        {
            return await GetDataAsync(Constants.TestImagesExtractedFileName, Constants.TestLabelsExtractedFileName);
        }

        private static async Task<byte[]> ReadFileContentsAsync(string filePath)
        {
            return await File.ReadAllBytesAsync(filePath);
        }

        private static int ReadInt32(IReadOnlyList<byte> data, int offset)
        {
            //  All the integers in the files are stored in the MSB first (high endian) format used by most non-Intel processors.
            //  Bit shifting and bitwise OR operations are used correct for this 
            //  http://yann.lecun.com/exdb/mnist/

            return (data[offset] << 24) | (data[offset + 1] << 16) | (data[offset + 2] << 8) | data[offset + 3];
        }

        private static int[,] ReadImage(IReadOnlyList<byte> imagesData, int offset, int numRows, int numCols)
        {
            var image = new int[numRows, numCols];
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numCols; col++)
                {
                    image[row, col] = imagesData[offset + row * numCols + col];
                }
            }
            return image;
        }

        private static List<DataItem> GetDataItems(IReadOnlyList<byte> imagesData, IReadOnlyList<byte> labelsData)
        {
            var dataItems = new List<DataItem>();

            var numberOfImages = ReadInt32(imagesData, 4);
            var numberOfRows = ReadInt32(imagesData, 8);
            var numberOfColumns = ReadInt32(imagesData, 12);

            for (var i = 0; i < numberOfImages; i++)
            {
                var label = (int)labelsData[8 + i];
                var offset = 16 + i * numberOfRows * numberOfColumns;
                var image = ReadImage(imagesData, offset, numberOfRows, numberOfColumns);

                dataItems.Add(new DataItem(label, image));
            }

            return dataItems;
        }

        private static async Task<List<DataItem>> GetDataAsync(string imagesFileName, string labelsFileName)
        {
            var binPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (binPath is null)
                throw new Exception("Unable to locate application folder");

            var imagesFileContents = await ReadFileContentsAsync(Path.Combine(binPath, Constants.AssetsPath, imagesFileName));
            var labelsFileContents = await ReadFileContentsAsync(Path.Combine(binPath, Constants.AssetsPath, labelsFileName));

            var items = GetDataItems(imagesFileContents, labelsFileContents);

            return items;
        }
    }
}
