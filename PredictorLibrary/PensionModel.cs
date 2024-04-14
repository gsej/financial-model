namespace PredictorLibrary;

public class PensionModel
{
    private readonly ModelParameters _modelParameters;
    private readonly IList<FiguresForYear> _years = new List<FiguresForYear>();
    private readonly ReturnRateCalculator _growthReturnRateCalculator;
    private readonly ReturnRateCalculator _minimalRiskReturnRateCalculator;

    public PensionModel(ModelParameters modelParameters)
    {
        _modelParameters = modelParameters;
        _growthReturnRateCalculator = new ReturnRateCalculator(modelParameters.GrowthReturnMean, modelParameters.GrowthReturnStandardDeviation);
        _minimalRiskReturnRateCalculator = new ReturnRateCalculator(modelParameters.MinimalRiskReturnMean, modelParameters.MinimalRiskReturnStandardDeviation);
    }

    public FiguresForYear GetYear(int index)
    {
        return _years[index];
    }

    public IEnumerable<FiguresForYear> Years => _years;
    
    
    public void Calculate()
    {
        var firstYear = CalculateFirstYear();
        _years.Add(firstYear);

        FiguresForYear lastYear;

        do
        {
            lastYear = _years.Last();
            var nextYear = CalculateYear(lastYear);
            _years.Add(nextYear);
        } while (lastYear.Year < _modelParameters.EndYear);
    }

    private FiguresForYear CalculateFirstYear()
    {
       // var amountAtStartOfYear = _modelParameters.AmountAtStart;
       // var growth = CalculateReturn(amountAtStartOfYear);
     //   var amountAtEndOfYear = amountAtStartOfYear + growth;

        var year = new FiguresForYear(
            Index: 0,
            Year: _modelParameters.StartYear,
            Age: _modelParameters.AgeAtStart,
            AmountAtEndOfPriorYear: _modelParameters.AmountAtStart,
            AnnualContribution: _modelParameters.AnnualContribution,
            AmountAtStartOfYear: _modelParameters.AmountAtStart,
            MinimalRiskAllocation: _modelParameters.MinimalRiskAllocation,
            GrowthAllocation: _modelParameters.GrowthAllocation,
            MinimalRiskReturn: _minimalRiskReturnRateCalculator.GetReturnRate(),
            GrowthReturn: _growthReturnRateCalculator.GetReturnRate()
        );

        return year;
    }

    private FiguresForYear CalculateYear(FiguresForYear previousYear)
    {
        var amountAtStartOfYear = previousYear.AmountAtEndOfYear + _modelParameters.AnnualContribution;
    //    var growth = CalculateReturn(amountAtStartOfYear);;
   //     var amountAtEndOfYear = amountAtStartOfYear + growth;

        var year = new FiguresForYear(
            Index: previousYear.Index + 1,
            Year: previousYear.Year + 1,
            Age: previousYear.Age + 1,
            AmountAtEndOfPriorYear: previousYear.AmountAtEndOfYear,
            AmountAtStartOfYear: amountAtStartOfYear,
            AnnualContribution: _modelParameters.AnnualContribution,
       //     Return: growth,
        //    AmountAtEndOfYear: amountAtEndOfYear,
            MinimalRiskAllocation: _modelParameters.MinimalRiskAllocation,
            GrowthAllocation: _modelParameters.GrowthAllocation,
            MinimalRiskReturn: _minimalRiskReturnRateCalculator.GetReturnRate(),
            GrowthReturn: _growthReturnRateCalculator.GetReturnRate()
        );
        
        return year;
    }

    private double CalculateReturn(double amountAtStartOfYear)
    {
        var returnRateForGrowth = _growthReturnRateCalculator.GetReturnRate();
        var returnRateForMinimalRisk = _minimalRiskReturnRateCalculator.GetReturnRate();
        
        var growthAllocation = amountAtStartOfYear * _modelParameters.GrowthAllocation;
        var growthReturn = growthAllocation * returnRateForGrowth;

        var minimalRiskAllocation = amountAtStartOfYear * _modelParameters.MinimalRiskAllocation;
        var minimalRiskReturn = minimalRiskAllocation * returnRateForMinimalRisk;

        return growthReturn + minimalRiskReturn;

        
        // =NORM.INV(RAND(),$G$12,$G$13)
        
        //https://stackoverflow.com/questions/2901750/is-there-a-c-sharp-library-that-will-perform-the-excel-norminv-function
        
    }
}