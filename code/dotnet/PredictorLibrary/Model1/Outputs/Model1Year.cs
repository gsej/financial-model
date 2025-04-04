namespace PredictorLibrary.Model1.Outputs;

public class Model1Year
{
    public int CalendarYear { get; set; }
    public int Age { get; set; }
    public int YearIndex { get; set; }
    public decimal PriorYear { get; set; }
    public decimal AmountAtStart { get; set; }
    public decimal InvestmentReturn { get; set; }
    public decimal AmountAtEnd => AmountAtStart + InvestmentReturn;
}