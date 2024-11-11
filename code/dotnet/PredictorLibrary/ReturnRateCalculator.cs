using MathNet.Numerics.Distributions;

namespace PredictorLibrary;

public static class Seeds
{
    public const int Default = 1; // This is the default seed for the random number generator used for consistency in testing.
}

public class ReturnRateCalculator : IReturnRateCalculator
{
    // Clamp the return rate to a reasonable range
    public const decimal SmallestReturnRate = -0.8m;
    public const decimal LargestReturnRate = 0.8m;
    
    private readonly Random _random;

    public ReturnRateCalculator()
    {
        _random = new Random();
    }
    
    public ReturnRateCalculator(int seed)
    {
        _random = new Random(seed);
    }
    
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