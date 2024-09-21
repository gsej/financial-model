namespace PredictorLibrary;

public class Model1Predictor
{
    private readonly ModelParameters _modelParameters;
    
    private PensionModel _model;
    
    public PensionModel Model => _model;

    public Model1Predictor(ModelParameters modelParameters)
    {
        _modelParameters = modelParameters;
    }
    
    public List<double> Predict(int iterations)
    {
        var finalAmounts = new List<double>();

        for (int i = 0; i < iterations; i++)
        {
            _model = new PensionModel(_modelParameters);
            _model.Calculate();

            var years = _model.Years;
            var finalYear = years.Last();
            
            finalAmounts.Add(finalYear.AmountAtEndOfYear);
        }

        return finalAmounts;
    }
}