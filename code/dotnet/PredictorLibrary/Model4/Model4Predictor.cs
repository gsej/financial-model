using MathNet.Numerics.Statistics;
using PredictorLibrary.Model3;
using PredictorLibrary.Model3.Inputs;
using PredictorLibrary.Model4.Inputs;
using PredictorLibrary.Model4.Outputs;

namespace PredictorLibrary.Model4;

public class Model4Predictor
{
    public Model4Prediction Generate(IReturnRateCalculator returnRateCalculator, Model4Inputs inputs)
    {
        // using the model 3 predictor to generate the data
        var model3Predictor = new Model3Predictor();

        var model3Inputs = new Model3Inputs
        {
            StartYear = 0, // In this model we don't care about the year as we are only interested in the target year
            AgeAtStart = inputs.AgeAtStart,
            EndYear = inputs.TargetAge - inputs.AgeAtStart,
            AmountAtStart = inputs.AmountAtStart,
            AnnualContribution = inputs.AnnualContribution,
            TargetAge = inputs.TargetAge,
            Allocations = inputs.Allocations.Select(a => new Model3.Inputs.Allocation
            {
                Name = a.Name,
                Proportion = a.Proportion,
                MeanAnnualReturn = a.MeanAnnualReturn,
                StandardDeviation = a.StandardDeviation
            }).ToList()
        };
        
        var prediction = new Model4Prediction();
        
        for (var i = 0; i < inputs.Iterations; i++)
        {
            var model3Prediction = model3Predictor.Generate(returnRateCalculator, model3Inputs);
            
            var amountAtTargetAge = model3Prediction.Years.SingleOrDefault(year => year.Age == inputs.TargetAge)?.AmountAtEnd;
            
            prediction.Iterations.Add(new Model4Iteration
            {
                Iteration = i,
                AmountAtTargetAge = amountAtTargetAge ?? 0,
            });
        }
        
        var amounts = prediction.Iterations.Select(i => i.AmountAtTargetAge).ToList();
        
        var mean = prediction.Iterations.Select(i => i.AmountAtTargetAge).Average();
        var minimum = prediction.Iterations.Select(i => i.AmountAtTargetAge).Min();
        var maximum = prediction.Iterations.Select(i => i.AmountAtTargetAge).Max();
        
        prediction.Mean = mean;
        prediction.Minimum = minimum;
        prediction.Maximum = maximum;

        var doubleAmounts = amounts.Select(a => (double)a).ToList();
        var p90Value = Statistics.Percentile(doubleAmounts, 99);

        var bands = new List<int>();

        var band = 0;
        while (true)
        {
            bands.Add(band);

            band += 200_000;

            if (band > p90Value)
            {
                break;
            }
        }
        bands.Add(100_000_000);
        
        for (var i = 1; i < bands.Count; i++)
        {
            prediction.Bands.Add(GetBand(amounts, bands[i-1], bands[i]));
        }
        
        for (var i = 1; i < bands.Count; i++)
        {
            prediction.CumulativeBands.Add(GetBand(amounts, 0, bands[i]));
        }
        
        return prediction;
    }
    
    private Band GetBand(IList<decimal> amounts, decimal lower, decimal upper)
    {
        var percentage = amounts.Count(a => a >= lower && a <= upper) / (double)amounts.Count;
        return new Band(lower, upper, percentage);
    }
}