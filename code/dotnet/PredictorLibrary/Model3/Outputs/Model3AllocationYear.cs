namespace PredictorLibrary.Model3.Outputs;

public record Model3AllocationYear
{
    public string Name { get; init; }
    public decimal AmountAtStart { get; init; }
    public decimal InvestmentReturn { get; init; }
}