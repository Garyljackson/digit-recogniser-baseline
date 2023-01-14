using DigitRecogniserBaseline.MNIST;

namespace DigitRecogniserBaseline.ConsoleApp
{
    internal static class DigitPredictor
    {
        public static int Predict(List<DataItem> trainedModel, DataItem digitToPredict)
        {
            
            var lossList = trainedModel
                .Select(modelItem => 
                    new {
                        modelItem, 
                        loss = LossCalculator.CalculateLoss(modelItem, digitToPredict)
                    });

            return lossList.OrderBy(arg => arg.loss).First().modelItem.Label;
        }

        public static bool IsPredictionAccurate(int prediction, DataItem digitToPredict)
        {
            return prediction == digitToPredict.Label;
        }

    }
}
