using PredictorLibrary.Model3.Inputs;
using PredictorLibrary.Model3.Outputs;

namespace PredictorLibrary.Model3;

public class Model3Predictor
{
    private readonly FixedPercentageRebalancer _rebalancer;
    public Model3Predictor()
    {
        _rebalancer = new FixedPercentageRebalancer();
    }
    public Model3Prediction Generate(IReturnRateCalculator returnRateCalculator, Model3Inputs inputs)
    {
        var prediction = new Model3Prediction();

        var amountFromPriorYear = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // add the annual contribution to the amount before calculating the investment return.
            // this pretends that the annual contribution is deposited at the start of each year, which is a simplification.
            
            var totalAmountAtStart = amountFromPriorYear + inputs.AnnualContribution;
            
            var allocationYears = new List<Model3AllocationYear>();
            
            foreach (var allocation in inputs.Allocations)
            {
                var rateOfReturn = returnRateCalculator.GetReturnRate(allocation.MeanAnnualReturn, allocation.StandardDeviation);

                var allocationAmountAtStart = _rebalancer.Rebalance(totalAmountAtStart, inputs.Allocations, allocation.Name);//////totalAmountAtStart * allocation.Proportion,
                var allocationYear = new Model3AllocationYear
                {
                    Name = allocation.Name,
                    AmountAtStart = allocationAmountAtStart,
                    RateOfReturn = rateOfReturn,
                    InvestmentReturn = allocationAmountAtStart * rateOfReturn
                };
                
                allocationYears.Add(allocationYear);
            }
            
            var year = new Model3Year
            {
                CalendarYear = y,
                Age = inputs.AgeAtStart + y - inputs.StartYear,
                YearIndex = y - inputs.StartYear,
                PriorYear  = amountFromPriorYear, 
                AmountAtStart = totalAmountAtStart,
                Allocations = allocationYears
            };
            prediction.Years.Add(year);
            amountFromPriorYear = year.AmountAtEnd;
        }

        prediction.TargetAge = inputs.TargetAge;
        prediction.AmountAtTargetAge = prediction.Years.SingleOrDefault(year => year.Age == inputs.TargetAge)?.AmountAtEnd;

        return prediction;   
    }
}

public class FixedPercentageRebalancer
{
    public decimal Rebalance(decimal totalPortfolioAmount, IList<Allocation> allocations, string allocationName)
    {
        var allocation = allocations.Single(a => a.Name == allocationName);
        return totalPortfolioAmount * allocation.Proportion;
    }
}