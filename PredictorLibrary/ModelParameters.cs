namespace PredictorLibrary;

public class PensionModel
{
    private readonly ModelParameters _modelParameters;
    private IList<YearFigures> _years = new List<YearFigures>();
    
    public PensionModel(ModelParameters modelParameters)
    {
        _modelParameters = modelParameters;
    }
   

    public YearFigures GetYear(int index)
    {
        return _years[index];
    }

    public void Calculate()
    {
        var firstYear = new YearFigures
        {
            Index = 0,
            Age = _modelParameters.AgeAtStart,
            AmountAtStartOfYear = _modelParameters.AmountAtStart  + _modelParameters.AnnualContribution,
            Year = _modelParameters.StartYear
        };

        var growth = firstYear.AmountAtStartOfYear * _modelParameters.GrowthReturn;
        var amount = firstYear.AmountAtStartOfYear + growth;

        firstYear.AmountAtEndOfYear = amount;   
        
        _years.Add(firstYear);

        var lastYear = firstYear;

        while (lastYear.Year < _modelParameters.EndYear)
        {
            var nextYear = new YearFigures
            {
                Index = lastYear.Index + 1,
                Age = lastYear.Age + 1,
                AmountAtStartOfYear = lastYear.AmountAtEndOfYear + _modelParameters.AnnualContribution,
                Year = lastYear.Year + 1,
                
            };

             growth = nextYear.AmountAtStartOfYear * _modelParameters.GrowthReturn;
             amount = nextYear.AmountAtStartOfYear + growth;
            
          //   amount = nextYear.AmountAtStartOfYear; // + growth

             nextYear.AmountAtEndOfYear = amount;
            
            _years.Add(nextYear);

            lastYear = nextYear;
        }
    }
}
public class ModelParameters
{
    public int StartYear { get; set; }
    public int AgeAtStart { get; set; }
    public int EndYear { get; set; }
    
    public decimal AmountAtStart { get; set; }
    
    
    // Contribution
    // this is a single value right now, but can be 
    // changed later (e.g. specify contributions for particular year / month

    public decimal AnnualContribution { get; set; }
    public decimal GrowthReturn { get; set; }
    public decimal GrowthAllocation { get; set; }
}

public class YearFigures
{
    public int Index { get; set; }
    public int Year { get; set; }
    public int Age { get; set; }
    public decimal AmountAtStartOfYear { get; set; }
    public decimal AmountAtEndOfYear { get; set; }
}
