using PredictorLibrary.Model2.Inputs;
using PredictorLibrary.Model2.Outputs;

namespace PredictorLibrary.Model2;

public class Model2Predictor
{
    public Model2Prediction Generate(Model2Inputs inputs)
    {
        var prediction = new Model2Prediction();

        var amountFromPriorYear = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // add the annual contribution to the amount before calculating the investment return.
            // this pretends that the annual contribution is deposited at the start of each year, which is a simplification.
            
            var amountAtStart = amountFromPriorYear + inputs.AnnualContribution;
            
            var allocationYears = new List<Model2AllocationYear>();
            
            foreach (var allocation in inputs.Allocations)
            {
                var allocationYear = new Model2AllocationYear
                {
                    Name = allocation.Name,
                    AmountAtStart = amountAtStart * allocation.Proportion,
                    InvestmentReturn = amountAtStart * allocation.Proportion * allocation.MeanAnnualReturn,
                };
                
                allocationYears.Add(allocationYear);
            }
            
            var year = new Model2Year
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