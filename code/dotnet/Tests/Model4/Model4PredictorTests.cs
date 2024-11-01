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
}