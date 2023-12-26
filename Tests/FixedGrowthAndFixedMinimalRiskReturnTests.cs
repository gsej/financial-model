using FluentAssertions;
using PredictorLibrary;

namespace Tests;

public class FixedGrowthReturnTests
{
    private ModelParameters _modelParameters;

    public FixedGrowthReturnTests()
    {
        _modelParameters = new ModelParameters
        {
            StartYear = 2024,
            AgeAtStart = 50,
            EndYear = 2044,
            AmountAtStart = 0m,
            AnnualContribution = 1000m,
            GrowthReturn = 0.05m,
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

        var expectedGrowth = firstYear.AmountAtStartOfYear * _modelParameters.GrowthReturn;
        
        // assert
        firstYear.Index.Should().Be(0);
        firstYear.Year.Should().Be(_modelParameters.StartYear);
        firstYear.Age.Should().Be(_modelParameters.AgeAtStart);
        firstYear.AmountAtStartOfYear.Should().Be(_modelParameters.AnnualContribution);
        firstYear.AmountAtEndOfYear.Should().Be(firstYear.AmountAtStartOfYear + expectedGrowth);
    }

    [Theory]
    [InlineData(0, 1050)]
    [InlineData(1, 2152.50 )]
    [InlineData(5, 7142.01 )]
    [InlineData(20, 37505.21 )]
    public void CanCalulateTotalForYear(int yearIndex, decimal expectedTotal)
    {
        // act
        var model = new PensionModel(_modelParameters);

        model.Calculate();
        
        // assert
        var yearFigures = model.GetYear(yearIndex);

        yearFigures.AmountAtEndOfYear.Should().BeApproximately(expectedTotal, 0.01m);
    }
}