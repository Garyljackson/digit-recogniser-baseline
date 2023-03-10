using System.IO.Compression;

namespace DigitRecogniserBaseline.MNIST
{
    internal static class ArchiveExtractor
    {
        // Data set archives downloaded from http://yann.lecun.com/exdb/mnist/
        
        private static async Task ExtractArchiveData(string archiveFileName, string outputFileName, string path)
        {
            var archivePath = Path.Combine(path, archiveFileName);
            var outputPath = Path.Combine(path, outputFileName);

            await using var fileToDecompressAsStream = File.OpenRead(archivePath);
            await using var decompressionStream = new GZipStream(fileToDecompressAsStream, CompressionMode.Decompress);
            await using var decompressedFileStream = File.Create(outputPath);
            await decompressionStream.CopyToAsync(decompressedFileStream);
        }

        internal static async Task ExtractAll()
        {
            var binPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (binPath is null)
                throw new Exception("Unable to locate application folder");

            var assetsPath = Path.Combine(binPath, Constants.AssetsPath);

            await ExtractArchiveData($"{Constants.TrainImagesArchiveFileName}", $"{Constants.TrainImagesExtractedFileName}", assetsPath);
            await ExtractArchiveData($"{Constants.TrainLabelsArchiveFileName}", $"{Constants.TrainLabelsExtractedFileName}", assetsPath);
            await ExtractArchiveData($"{Constants.TestImagesArchiveFileName}", $"{Constants.TestImagesExtractedFileName}", assetsPath);
            await ExtractArchiveData($"{Constants.TestLabelsArchiveFileName}", $"{Constants.TestLabelsExtractedFileName}", assetsPath);

        }
    }
}
