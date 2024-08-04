namespace PredictorLibrary.Model1;

public class Predictor
{
    public Model1Prediction Generate(Model1Inputs inputs)
    {
        var prediction = new Model1Prediction();

        var amountAtStart = inputs.AmountAtStart;
        
        for (var y = inputs.StartYear; y <= inputs.EndYear; y++)
        {
            // GSEJ: the rounding shouldn't happen here... but at the end. Perhaps when converting to json. 

            var investmentReturn = amountAtStart * inputs.MeanAnnualReturn;
            var year = new Year
            {
                CalendarYear = y,
                Age = inputs.AgeAtStart + y - inputs.StartYear,
                YearIndex = y - inputs.StartYear,
                AmountAtStart = Math.Round(amountAtStart, 2),
                AnnualContribution = Math.Round(inputs.AnnualContribution, 2),
                InvestmentReturn = Math.Round(investmentReturn, 2),
                AmountAtEnd = Math.Round(amountAtStart + inputs.AnnualContribution + investmentReturn, 2)
            };
            prediction.Years.Add(year);
            amountAtStart = year.AmountAtEnd;
        }

        return prediction;   
    }
}