namespace PredictorLibrary.Model3.Outputs;

public class Model3Year
{
    public int CalendarYear { get; set; }
    public int Age { get; set; }
    public int YearIndex { get; set; }
    public decimal PriorYear { get; set; }
    public decimal AmountAtStart { get; set; }

    public decimal InvestmentReturn
    {
        get { return Allocations.Sum(allocation => allocation.InvestmentReturn); }
    }

    public IList<Model3AllocationYear> Allocations { get; set; } = new List<Model3AllocationYear>();

    public decimal AmountAtEnd => AmountAtStart + InvestmentReturn;
}