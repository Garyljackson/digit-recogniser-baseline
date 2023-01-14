using DigitRecogniserBaseline.ConsoleApp;
using DigitRecogniserBaseline.MNIST;

var data = await DataReader.ReadDataAsync();

var averagedDigits = ModelTrainer.Train(data);

var predictionList = new List<Prediction>();

foreach (var testDataItem in data.TestingData)
{
    var prediction = DigitPredictor.Predict(averagedDigits, testDataItem);
    var isAccuratePrediction = DigitPredictor.IsPredictionAccurate(prediction, testDataItem);

    predictionList.Add(new Prediction(prediction, isAccuratePrediction));
    
}

var groupedPredictions = predictionList
    .OrderBy(prediction => prediction.Predicted)
    .GroupBy(prediction => prediction.Predicted);

double overAllAccuracy = 0;

foreach (var groupedPrediction in groupedPredictions)
{
    double total = groupedPrediction.Count();
    
    double correctPredictions = groupedPrediction.Count(tuple => tuple.IsAccurate);

    var accuracy = correctPredictions / total;

    Console.WriteLine($"Accuracy for :{groupedPrediction.Key} - {accuracy}");
    
    overAllAccuracy += accuracy;
}

Console.WriteLine($"Overall Accuracy: {overAllAccuracy/10}");