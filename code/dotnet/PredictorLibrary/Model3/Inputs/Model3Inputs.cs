namespace PredictorLibrary.Model3.Inputs;

public class Model3Inputs {
    public int StartYear { get; set; }
    public int AgeAtStart { get; set; }
    public int EndYear { get; set; }
    public decimal AmountAtStart { get; set; }
    public decimal AnnualContribution { get; set; }
    public int TargetAge { get; set; }
    
    public IList<Allocation> Allocations { get; set; } = new List<Allocation>();
}