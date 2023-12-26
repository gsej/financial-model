using MathNet.Numerics.Distributions;

namespace PredictorLibrary;

public class ReturnRateCalculator
{
    private readonly Normal _normal;

    public ReturnRateCalculator(double mean, double standardDeviation)
    {
        var random = new Random();
        _normal = new Normal(mean, standardDeviation, random);  
    }
    
    public double GetReturnRate()
    {
        return _normal.Sample();
    }
}