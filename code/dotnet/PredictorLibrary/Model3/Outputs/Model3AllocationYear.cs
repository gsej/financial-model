using System.Diagnostics;

namespace PredictorLibrary.Model3.Outputs;

[DebuggerDisplay("Name = {Name}, AmountAtStart = {AmountAtStart}, RateOfReturn = {RateOfReturn}, InvestmentReturn = {InvestmentReturn}")]
public record Model3AllocationYear
{
    public string Name { get; init; }
    public decimal AmountAtStart { get; init; }
    public decimal RateOfReturn { get; init; }
    public decimal InvestmentReturn { get; init; }
}