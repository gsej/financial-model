namespace PredictorLibrary.Model2.Outputs;

public record Model2AllocationYear
{
    public string Name { get; init; }
    public decimal AmountAtStart { get; init; }
    public decimal InvestmentReturn { get; init; }
}