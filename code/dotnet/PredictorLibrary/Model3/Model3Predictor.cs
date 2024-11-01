using PredictorLibrary.Model3.Inputs;
using PredictorLibrary.Model3.Outputs;

namespace PredictorLibrary.Model3;

public class Model3Predictor
{
    public Model3Prediction Generate(IReturnRateCalculator returnRateCalculator, Model3Inputs inputs)
    {
        var prediction = new Model3Prediction();

        var amountFromPriorYear = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // add the annual contribution to the amount before calculating the investment return.
            // this pretends that the annual contribution is deposited at the start of each year, which is a simplification.
            
            var amountAtStart = amountFromPriorYear + inputs.AnnualContribution;
            
            var allocationYears = new List<Model3AllocationYear>();
            
            foreach (var allocation in inputs.Allocations)
            {
                var rateOfReturn = returnRateCalculator.GetReturnRate(allocation.MeanAnnualReturn, allocation.StandardDeviation);
                var allocationYear = new Model3AllocationYear
                {
                    Name = allocation.Name,
                    AmountAtStart = amountAtStart * allocation.Proportion,
                    RateOfReturn = rateOfReturn,
                    InvestmentReturn = amountAtStart * allocation.Proportion * rateOfReturn
                };
                
                allocationYears.Add(allocationYear);
            }
            
            var year = new Model3Year
            {
                CalendarYear = y,
                Age = inputs.AgeAtStart + y - inputs.StartYear,
                YearIndex = y - inputs.StartYear,
                PriorYear  = amountFromPriorYear, 
                AmountAtStart = amountAtStart,
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