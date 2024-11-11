using FluentAssertions;
using PredictorLibrary;
using Tests.Model4;
using Xunit.Abstractions;

namespace Tests;

// The return rate calculator returns random values from a modified normal distribution,
// so we can't test for exact values. Instead, we'll test some of the properties of the output
// using multiple iterations to ensure that the results are close to the expected values.
public class ReturnRateCalculatorTests
{
    private readonly ITestOutputHelper _output;

    public ReturnRateCalculatorTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void GetReturnRate_ResultsShouldApproachMeanRateOfReturn()
    {
        var iterations = 10_000_000;
        
        var expectedMean = 0.05m;
        var standardDeviation = 0.15m;
        
        var calculator = new ReturnRateCalculator(Seeds.Default);
        
        var rates = new List<decimal>(iterations);
               
        for (var i = 0; i < iterations; i++)
        {
            rates.Add(calculator.GetReturnRate(expectedMean, standardDeviation));
        }

        var actualMean = rates.Average();

        actualMean.Should().BeApproximately(expectedMean, 0.0001m);
    }
    
    [Fact]
    public void GetReturnRate_ValuesLessThanMinusOneSholudBeSmalln()
    {
        // We want to clamp the largest drop in a single year to -80%
        // and the largest gain to 80% to prevent the model from going crazy.
        
        var iterations = 10_000_000;
        
        var calculator = new ReturnRateCalculator(Seeds.Default);

        var expectedMean = 0.05m;
        var standardDeviation = 0.25m;
        
        var rates = new List<decimal>(iterations);
        
        for (var i = 0; i < iterations; i++)
        {
            rates.Add(calculator.GetReturnRate(expectedMean, standardDeviation));
        }
        
        var numberBelowThreshold = rates.Count(r => r < ReturnRateCalculator.SmallestReturnRate );
        var percentageBelowThreshold = 100*(double)numberBelowThreshold/iterations;
        var numberAboveThreshold = rates.Count(r => r > ReturnRateCalculator.LargestReturnRate );
        var percentageAbovethreshold = 100*(double)numberAboveThreshold/iterations;
        
        _output.WriteLine($"Number below threshold: {numberBelowThreshold} or {percentageBelowThreshold}%");
        _output.WriteLine($"Number above threshold: {numberAboveThreshold} or {percentageAbovethreshold}%");
        
        numberBelowThreshold.Should().Be(0);
        numberAboveThreshold.Should().Be(0);
    }
}