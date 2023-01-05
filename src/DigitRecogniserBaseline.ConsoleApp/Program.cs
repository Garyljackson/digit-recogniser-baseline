// See https://aka.ms/new-console-template for more information

using DigitRecogniserBaseline.MNIST;

var data = await DataReader.ReadDataAsync();


// Test to see the some images
var count = 0;
foreach (var item in data.TrainingData.Take(20))
{
    await ImageWriter.WriteImageToFileAsync(item.Image, $"{count}-{item.Label}.bmp");
    count++;
}

Console.WriteLine("Hello, World!");