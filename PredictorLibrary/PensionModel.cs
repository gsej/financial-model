namespace PredictorLibrary;

public class PensionModel(ModelParameters modelParameters)
{
    private readonly IList<FiguresForYear> _years = new List<FiguresForYear>();

    public FiguresForYear GetYear(int index)
    {
        return _years[index];
    }

    public void Calculate()
    {
        var amountAtStartOfYear = modelParameters.AmountAtStart + modelParameters.AnnualContribution;
        var growth = amountAtStartOfYear * modelParameters.GrowthReturn;
        var amountAtEndOfYear = amountAtStartOfYear + growth;

        var firstYear = new FiguresForYear(
            Index: 0,
            Year: modelParameters.StartYear,
            Age: modelParameters.AgeAtStart,
            AmountAtStartOfYear: amountAtStartOfYear,
            AmountAtEndOfYear: amountAtEndOfYear);
        
        _years.Add(firstYear);

        var lastYear = _years.Last();

        while (lastYear.Year < modelParameters.EndYear)
        {
            var nextYear = CalculateYear(lastYear);
            
            _years.Add(nextYear);

            lastYear = nextYear;
        }
        
        
    }

    private FiguresForYear CalculateYear(FiguresForYear previousYear)
    {
        var amountAtStartOfYear = previousYear.AmountAtEndOfYear + modelParameters.AnnualContribution;
        var growth = amountAtStartOfYear * modelParameters.GrowthReturn;
        var amountAtEndOfYear = amountAtStartOfYear + growth;
        
        var year = new FiguresForYear(
            Index: previousYear.Index + 1,
            Year: previousYear.Year +1,
            Age: previousYear.Age + 1,
            AmountAtStartOfYear: amountAtStartOfYear,
            AmountAtEndOfYear: amountAtEndOfYear);

        return year;
    }
}