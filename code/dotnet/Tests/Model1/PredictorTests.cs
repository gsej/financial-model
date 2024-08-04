using FluentAssertions;
using PredictorLibrary.Model1;

namespace Tests.Model1;

public class PredictorTests
{
    private readonly Predictor _predictor = new ();
    
    [Fact]
    public void Generate_GeneratesCorrectYearValues()
    {
        var inputs = new Model1Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            MeanAnnualReturn = 0m
        };
        
        // act
        var prediction = _predictor.Generate(inputs);
        
        // assert
        prediction.Years.ElementAt(0).CalendarYear.Should().Be(2020);
        prediction.Years.ElementAt(0).YearIndex.Should().Be(0);
        prediction.Years.ElementAt(0).Age.Should().Be(30);
        
        prediction.Years.ElementAt(1).CalendarYear.Should().Be(2021);
        prediction.Years.ElementAt(1).YearIndex.Should().Be(1);
        prediction.Years.ElementAt(1).Age.Should().Be(31);
        
        prediction.Years.ElementAt(2).CalendarYear.Should().Be(2022);
        prediction.Years.ElementAt(2).YearIndex.Should().Be(2);
        prediction.Years.ElementAt(2).Age.Should().Be(32);
    }
    
    [Fact]
    public void Generate_ShouldHaveCorrectFixedValues()
    {
        var inputs = new Model1Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            MeanAnnualReturn = 0m
        };
        
        // act
        var prediction = _predictor.Generate(inputs);
        
        // assert
        prediction.Years.Should().AllSatisfy(year => year.AnnualContribution.Should().Be(inputs.AnnualContribution));
    }
    
    [Fact]
    public void Generate_WithZeroMeanAnnualReturn_ShouldHaveCorrectInvestmentReturn()
    {
        var inputs = new Model1Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            MeanAnnualReturn = 0m
        };
        
        // act
        var prediction = _predictor.Generate(inputs);
        
        // assert
        prediction.Years.Should().AllSatisfy(year => year.InvestmentReturn.Should().Be(0));
    }
    
    [Fact]
    public void Generate_WithZeroReturn_ShouldHaveCorrectStartValues()
    {
        var inputs = new Model1Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            MeanAnnualReturn = 0m
        };
        
        // act
        var prediction = _predictor.Generate(inputs);
        
        // assert
        prediction.Years.ElementAt(0).AmountAtStart.Should().Be(inputs.AmountAtStart);
        
        foreach (var year in prediction.Years.Where(year => year.YearIndex > 0))
        {
            var previousYear = prediction.Years.ElementAt(year.YearIndex - 1);
            year.AmountAtStart.Should().Be(previousYear.AmountAtEnd);
        };
    }
    
    [Fact]
    public void Generate_ShouldHaveCorrectEndValues()
    {
        var inputs = new Model1Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            MeanAnnualReturn = 0m
        };
        
        // act
        var prediction = _predictor.Generate(inputs);
        
        // assert
        foreach (var year in prediction.Years)
        {
            year.AmountAtEnd.Should().Be(year.AmountAtStart + year.InvestmentReturn + year.AnnualContribution);
        };
    }
}