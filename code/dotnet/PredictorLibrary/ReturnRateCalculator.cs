using MathNet.Numerics.Distributions;

namespace PredictorLibrary;

public class ReturnRateCalculator : IReturnRateCalculator
{
    // Clamp the return rate to a reasonable range
    public const decimal SmallestReturnRate = -0.8m;
    public const decimal LargestReturnRate = 0.8m;
    
    private readonly Random _random = new();
    
    public decimal GetReturnRate(decimal mean, decimal standardDeviation)
    {
        var normal = new Normal((double)mean, (double)standardDeviation, _random);
        
        var sample = (decimal)normal.Sample();

        return sample switch
        {
            < SmallestReturnRate => SmallestReturnRate,
            > LargestReturnRate => LargestReturnRate,
            _ => sample
        };
    }
}