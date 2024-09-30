using FluentAssertions;
using PredictorLibrary;


namespace Tests;

public class ReturnRateCalculatorTests
{
    [Fact]
    public void GetReturnRate_ResultsShouldApproachMeanRateOfReturn()
    {
        var calculator = new ReturnRateCalculator();

        var iterations = 50000;
        
        var results = new List<decimal>(iterations);

        decimal expectedMean = 0.05m;
        
        decimal standardDeviation = 0.15m;
        
        for (int i = 0; i < iterations; i++)
        {
            var rate = calculator.GetReturnRate(expectedMean, standardDeviation);
            results.Add(rate);
        }

        var actualMean = results.Average();

        actualMean.Should().BeApproximately(expectedMean, 0.001m);
    }
}