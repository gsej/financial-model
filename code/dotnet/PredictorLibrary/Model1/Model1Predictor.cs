using PredictorLibrary.Model1.Inputs;
using PredictorLibrary.Model1.Outputs;

namespace PredictorLibrary.Model1;

public class Model1Predictor
{
    public Model1Prediction Generate(Model1Inputs inputs)
    {
        var prediction = new Model1Prediction();

        var amountFromPriorYear = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // add the annual contribution to the amount before calculating the investment return.
            // this pretends that the annual contribution is deposited at the start of each year, which is a simplification.

            var amountAtStart = amountFromPriorYear + inputs.AnnualContribution;
            
            var investmentReturn = amountAtStart * inputs.MeanAnnualReturn;
            var year = new Model1Year
            {
                CalendarYear = y,
                Age = inputs.AgeAtStart + y - inputs.StartYear,
                YearIndex = y - inputs.StartYear,
                PriorYear  = amountFromPriorYear, 
                AmountAtStart = amountAtStart,
                InvestmentReturn = investmentReturn
            };
            prediction.Years.Add(year);
            amountFromPriorYear = year.AmountAtEnd;
        }

        prediction.TargetAge = inputs.TargetAge;
        prediction.AmountAtTargetAge = prediction.Years.SingleOrDefault(year => year.Age == inputs.TargetAge)?.AmountAtEnd;

        return prediction;   
    }
}