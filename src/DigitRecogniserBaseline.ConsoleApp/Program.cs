using DigitRecogniserBaseline.ConsoleApp;
using DigitRecogniserBaseline.MNIST;

var data = await DataReader.ReadDataAsync();

var averagedDigits = ModelTrainer.Train(data);

foreach (var item in averagedDigits)
{
    await ImageWriter.WriteImageToFileAsync(item.Image, $"{item.Label}.bmp");
}

Console.WriteLine("Hello, World!");