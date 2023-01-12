using DigitRecogniserBaseline.ConsoleApp;
using DigitRecogniserBaseline.MNIST;

var data = await DataReader.ReadDataAsync();

var averagedDigits = ModelTrainer.Train(data);

var idealThree = averagedDigits.First(item => item.Label == 3);
var idealSeven = averagedDigits.First(item => item.Label == 7);

var testThree = data.TestingData.First(item => item.Label == 3);

await ImageWriter.WriteImageToFileAsync(idealThree.Image, "IdealThree.bmp");
await ImageWriter.WriteImageToFileAsync(idealSeven.Image, "IdealSeven.bmp");
await ImageWriter.WriteImageToFileAsync(testThree.Image, "TestThree.bmp");

var lossThree = LossCalculator.CalculateRootMeanSquaredError(idealThree, testThree);
var lossSeven = LossCalculator.CalculateRootMeanSquaredError(idealSeven, testThree);

Console.WriteLine($"3 loss: {lossThree}");
Console.WriteLine($"7 loss: {lossSeven}");

Console.WriteLine("Hello, World!");