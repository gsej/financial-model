using FluentAssertions;
using PredictorLibrary.Model2;
using PredictorLibrary.Model2.Inputs;

namespace Tests.Model2;

public class Model2PredictorTests
{
    private readonly Model2Predictor _model2Predictor = new ();
    
    [Fact]
    public void Generate_GeneratesCorrectYearValues()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
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
        var prediction = _model2Predictor.Generate(inputs);
        
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
    public void Generate_WithZeroMeanAnnualReturn_ShouldHaveCorrectInvestmentReturn()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
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
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        prediction.Years.Should().AllSatisfy(year => year.InvestmentReturn.Should().Be(0));
    }
    
    [Fact]
    public void Generate_WithZeroReturn_ShouldHaveCorrectStartValues()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
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
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        prediction.Years.ElementAt(0).PriorYear.Should().Be(inputs.AmountAtStart);
        prediction.Years.ElementAt(0).AmountAtStart.Should().Be(inputs.AmountAtStart + inputs.AnnualContribution);
        
        prediction.Years.ElementAt(1).PriorYear.Should().Be(prediction.Years.ElementAt(0).AmountAtEnd);
        prediction.Years.ElementAt(1).AmountAtStart.Should().Be(prediction.Years.ElementAt(1).PriorYear + inputs.AnnualContribution);
        
        prediction.Years.ElementAt(2).PriorYear.Should().Be(prediction.Years.ElementAt(1).AmountAtEnd);
        prediction.Years.ElementAt(2).AmountAtStart.Should().Be(prediction.Years.ElementAt(2).PriorYear + inputs.AnnualContribution);
    }
    
    [Fact]
    public void Generate_ShouldHaveCorrectEndValues()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
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
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        foreach (var year in prediction.Years)
        {
            year.AmountAtEnd.Should().Be(year.AmountAtStart + year.InvestmentReturn);
        };
    }
    
    [Fact]
    public void Generate_ShouldPopulateAmountAtTargetAge()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            //AgeAtStart = 30,
            EndYear = 2100,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Equities",
                    Proportion = 1,
                    MeanAnnualReturn = 0
                }
            },
            TargetAge = 67
        };
        // act
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        prediction.TargetAge.Should().Be(inputs.TargetAge);
        prediction.AmountAtTargetAge.Should().Be(prediction.Years.Single(year => year.Age == inputs.TargetAge).AmountAtEnd);
    }
    
    [Fact]
    public void Generate_WithSingle_Allocation_ShouldCalculateInvestmentReturn()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Equities",
                    Proportion = 1,
                    MeanAnnualReturn = 0.05m
                }
            },
        };
        // act
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        prediction.Years.ElementAt(0).InvestmentReturn.Should().Be(100);
        prediction.Years.ElementAt(0).AmountAtEnd.Should().Be(2100);
        
        prediction.Years.ElementAt(1).InvestmentReturn.Should().Be(155);
        prediction.Years.ElementAt(1).AmountAtEnd.Should().Be(3255);
        
        prediction.Years.ElementAt(2).InvestmentReturn.Should().Be(212.75m);
        prediction.Years.ElementAt(2).AmountAtEnd.Should().Be(4467.75m);
    }
    
    [Fact]
    public void Generate_WithTwo_Allocations_ShouldCalculateInvestmentReturn()
    {
        var inputs = new Model2Inputs
        {
            StartYear = 2020,
            AgeAtStart = 30,
            EndYear = 2023,
            AmountAtStart = 1000,
            AnnualContribution = 1000,
            Allocations = new List<Allocation>
            {
                new ()
                {
                    Name = "Equities",
                    Proportion = 0.8m,
                    MeanAnnualReturn = 0.05m
                },
                new ()
                {
                    Name = "Minimal Risk",
                    Proportion = 0.2m,
                    MeanAnnualReturn = 0.01m
                }
            },
        };
        // act
        var prediction = _model2Predictor.Generate(inputs);
        
        // assert
        prediction.Years.ElementAt(0).InvestmentReturn.Should().Be(84);
        prediction.Years.ElementAt(0).AmountAtEnd.Should().Be(2084);
        
        prediction.Years.ElementAt(1).InvestmentReturn.Should().BeApproximately(129.528m, 0.001m);
        prediction.Years.ElementAt(1).AmountAtEnd.Should().BeApproximately(3213.528m, 0.001m);
        
        prediction.Years.ElementAt(2).InvestmentReturn.Should().BeApproximately(176.968m, 0.001m);
        prediction.Years.ElementAt(2).AmountAtEnd.Should().BeApproximately(4390.496m, 0.001m);
    }
}