using MathNet.Numerics.Distributions;

namespace PredictorLibrary;

public class ReturnRateCalculator : IReturnRateCalculator
{
    private readonly Random _random = new();
    
    public decimal GetReturnRate(decimal mean, decimal standardDeviation)
    {
        var normal = new Normal((double)mean, (double)standardDeviation, _random);
        return (decimal)normal.Sample();
    }
}