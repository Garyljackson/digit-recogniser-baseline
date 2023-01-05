using System.IO.Compression;

namespace DigitRecogniserBaseline.ConsoleApp
{
    internal static class ArchiveExtractor
    {
        // Dataset archives downloaded from http://yann.lecun.com/exdb/mnist/

        private const string TrainImagesName = "train-images-idx3-ubyte";
        private const string TrainLabelsName = "train-labels-idx1-ubyte";
        private const string TestImagesName = "t10k-images-idx3-ubyte";
        private const string TestLabelsName = "t10k-labels-idx1-ubyte";
        private const string AssetsPath = "assets";
        
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

            var assetsPath = Path.Combine(binPath, AssetsPath);

            await ExtractArchiveData($"{TrainImagesName}.gz", $"{TrainImagesName}_Extracted", assetsPath);
            await ExtractArchiveData($"{TrainLabelsName}.gz", $"{TrainLabelsName}_Extracted", assetsPath);
            await ExtractArchiveData($"{TestImagesName}.gz", $"{TestImagesName}_Extracted", assetsPath);
            await ExtractArchiveData($"{TestLabelsName}.gz", $"{TestLabelsName}_Extracted", assetsPath);

        }
    }
}
