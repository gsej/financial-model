namespace PredictorLibrary;

public class Predictor
{
    private readonly ModelParameters _modelParameters;

    public Predictor(ModelParameters modelParameters)
    {
        _modelParameters = modelParameters;
    }
    public List<double> Predict(int iterations)
    {
        var finalAmounts = new List<double>();

        for (int i = 0; i < iterations; i++)
        {
            var pensionModel = new PensionModel(_modelParameters);
            pensionModel.Calculate();

            var years = pensionModel.Years();
            var finalYear = years.Last();
            
            finalAmounts.Add(finalYear.AmountAtEndOfYear);
        }

        return finalAmounts;
    }
}