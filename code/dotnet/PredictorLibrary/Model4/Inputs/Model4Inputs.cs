namespace PredictorLibrary.Model4.Inputs;

public class Model4Inputs {
    
    public int AgeAtStart { get; set; }
    public decimal AmountAtStart { get; set; }
    public decimal AnnualContribution { get; set; }
    public int TargetAge { get; set; }
    public int Iterations { get; set; }
    public IList<Allocation> Allocations { get; set; } = new List<Allocation>();
    
    public int? RandomSeed { get; set; }
}