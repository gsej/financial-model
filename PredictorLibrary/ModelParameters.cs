namespace PredictorLibrary;

public class ModelParameters
{
    public int StartYear { get; init; }
    public int AgeAtStart { get; init; }
    public int EndYear { get; init; }
    
    public double AmountAtStart { get; init; }
    
    // Contribution
    // this is a single value right now, but can be 
    // changed later (e.g. specify contributions for particular year / month

    // The annual contribution is assumed to be applied right after the start of the year. 
    public double AnnualContribution { get; init; }
    
    public double GrowthReturnMean { get; init; }
    public double GrowthReturnStandardDeviation { get; set; }
    public double GrowthAllocation { get; init; }
    
    public double MinimalRiskReturnMean { get; set; }
    public double MinimalRiskReturnStandardDeviation { get; set; }

    public double MinimalRiskAllocation => 1 - GrowthAllocation;
}