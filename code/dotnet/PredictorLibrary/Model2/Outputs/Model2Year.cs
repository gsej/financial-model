namespace PredictorLibrary.Model2.Outputs;

public class Model2Year
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

    public IList<Model2AllocationYear> Allocations { get; set; } = new List<Model2AllocationYear>();

    public decimal AmountAtEnd => AmountAtStart + InvestmentReturn;
}