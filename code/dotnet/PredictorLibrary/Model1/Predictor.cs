namespace PredictorLibrary.Model1;

public class Predictor
{
    public Model1Prediction Generate(Model1Inputs inputs)
    {
        var prediction = new Model1Prediction();

        var amountAtStart = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // add the annual contribution to the amount before calculating the investment return.
            // this pretends that the annual contribution is deposited at the start of each year, which is a simplification.
            
            var investmentReturn = (amountAtStart + inputs.AnnualContribution) * inputs.MeanAnnualReturn;
            var year = new Year
            {
                CalendarYear = y,
                Age = inputs.AgeAtStart + y - inputs.StartYear,
                YearIndex = y - inputs.StartYear,
                PriorYear  = amountAtStart, 
                AmountAtStart = amountAtStart + inputs.AnnualContribution,
                InvestmentReturn = investmentReturn,
                AmountAtEnd = amountAtStart + inputs.AnnualContribution + investmentReturn,
            };
            prediction.Years.Add(year);
            amountAtStart = year.AmountAtEnd;
        }

        prediction.TargetAge = inputs.TargetAge;
        prediction.AmountAtTargetAge = prediction.Years.SingleOrDefault(year => year.Age == inputs.TargetAge)?.AmountAtEnd;

        return prediction;   
    }
}