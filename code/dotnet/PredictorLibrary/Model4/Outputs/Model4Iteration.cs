namespace PredictorLibrary.Model4.Outputs;

public class Model4Iteration
{
    public int Iteration { get; set; }
    public decimal AmountAtTargetAge { get; set; }
    
    
    public List <Model4Allocation> Allocations { get; set; } = new();
    
}