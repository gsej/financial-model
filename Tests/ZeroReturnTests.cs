using FluentAssertions;
using PredictorLibrary;

namespace Tests;

public class ZeroReturnTests
{
    private ModelParameters _modelParameters;

    public ZeroReturnTests()
    {
        _modelParameters = new ModelParameters
        {
            StartYear = 2024,
            AgeAtStart = 50,
            EndYear = 2044,
            AmountAtStart = 0m,
            AnnualContribution = 1000m,
            GrowthReturn = 0m,
            GrowthAllocation = 1m
        };
    }
    
    [Fact]
    public void CanSetupFirstYear()
    {
       // act
        var model = new PensionModel(_modelParameters);
        model.Calculate();

        var firstYear = model.GetYear(0);
        
        // assert
        firstYear.Index.Should().Be(0);
        firstYear.Year.Should().Be(_modelParameters.StartYear);
        firstYear.Age.Should().Be(_modelParameters.AgeAtStart);
        firstYear.AmountAtStartOfYear.Should().Be(_modelParameters.AnnualContribution);
        firstYear.AmountAtEndOfYear.Should().Be(firstYear.AmountAtStartOfYear);
    }

    [Theory]
    [InlineData(1, 2000)]
    [InlineData(5, 6000)]
    [InlineData(20, 21000)]
    public void CanCalulateTotalForYear(int yearIndex, decimal expectedTotal)
    {
        // act
        var model = new PensionModel(_modelParameters);

        model.Calculate();
        
        // assert
        var yearFigures = model.GetYear(yearIndex);

        yearFigures.AmountAtEndOfYear.Should().Be(expectedTotal);
    }
}