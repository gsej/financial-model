using FluentAssertions;
using NSubstitute;
using PredictorLibrary;
using PredictorLibrary.Model4;
using PredictorLibrary.Model4.Inputs;

namespace Tests.Model4;

public class Model4PredictorTests
{
    private readonly Model4Predictor _model4Predictor = new ();

    [Fact]
    public void Generate_GeneratesCorrectNumberOfIterations()
    {
        var inputs = new Model4Inputs
        {
            AgeAtStart = 30,
            TargetAge = 50,
            AmountAtStart = 1000,
            AnnualContribution = 0,
            Iterations = 100,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Equities",
                    Proportion = 1,
                    MeanAnnualReturn = 0
                }
            }
        };
        
        // act
        var prediction = _model4Predictor.Generate(Substitute.For<ReturnRateCalculator>(), inputs);
        
        // assert
        prediction.Iterations.Count.Should().Be(inputs.Iterations);

        prediction.Minimum.Should().Be(1000m);
        prediction.Mean.Should().Be(1000m);
        prediction.Maximum.Should().Be(1000m);
    }
    
    [Fact]
    public void Generate_GeneratesCorrectAmountAtTargetAge()
    {
        var inputs = new Model4Inputs
        {
            AgeAtStart = 30,
            TargetAge = 50,
            AmountAtStart = 1000,
            AnnualContribution = 0,
            Iterations = 3,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Growth",
                    Proportion = 0.8m,
                    MeanAnnualReturn = 0.05m,
                    StandardDeviation = 0.25m
                },
                new ()
                {
                    Name = "MinimalRisk",
                    Proportion = 0.2m,
                    MeanAnnualReturn = 0.01m,
                    StandardDeviation = 0m
                }
            }
        };
        
        // act
        var returnRateCalculator = new ReturnRateCalculator(seed: 1); // seed is set to 1 to ensure consistent results
        
        var prediction = _model4Predictor.Generate(returnRateCalculator, inputs);
        
        // assert
        prediction.Iterations[0].AmountAtTargetAge.Should().Be(1202.3614429231596891950025134m);
        prediction.Iterations[1].AmountAtTargetAge.Should().Be(908.5675970309434895470214385m);
        prediction.Iterations[2].AmountAtTargetAge.Should().Be(744.51249151762212927709712419m);
    }
    
    [Fact]
    public void Generate_GeneratesCorrectAllocationTotalsAtTargetAge()
    {
        var inputs = new Model4Inputs
        {
            AgeAtStart = 30,
            TargetAge = 50,
            AmountAtStart = 1000,
            AnnualContribution = 0,
            Iterations = 3,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Growth",
                    Proportion = 0.8m,
                    MeanAnnualReturn = 0.05m,
                    StandardDeviation = 0.25m
                },
                new ()
                {
                    Name = "MinimalRisk",
                    Proportion = 0.2m,
                    MeanAnnualReturn = 0.01m,
                    StandardDeviation = 0m
                }
            }
        };
        
        // act
        var returnRateCalculator = new ReturnRateCalculator(seed: 1); // seed is set to 1 to ensure consistent results
        
        var prediction = _model4Predictor.Generate(returnRateCalculator, inputs);
        
        // assert
        prediction.Iterations[0].Allocations.Sum(a => a.AmountAtTargetAge).Should().Be(1202.3614429231596891950025134m);
        prediction.Iterations[1].Allocations.Sum(a => a.AmountAtTargetAge).Should().Be(908.5675970309434895470214385m);
        prediction.Iterations[2].Allocations.Sum(a => a.AmountAtTargetAge).Should().Be(744.51249151762212927709712419m);
    }
}