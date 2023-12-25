namespace PredictorLibrary;

public class ModelParameters
{
    public int StartYear { get; init; }
    public int AgeAtStart { get; init; }
    public int EndYear { get; init; }
    
    public decimal AmountAtStart { get; init; }
    
    // Contribution
    // this is a single value right now, but can be 
    // changed later (e.g. specify contributions for particular year / month

    public decimal AnnualContribution { get; init; }
    public decimal GrowthReturn { get; init; }
    public decimal GrowthAllocation { get; init; }
}