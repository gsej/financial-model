namespace PredictorLibrary.Model1.Outputs;

public class Model1Prediction
{
    public List<Model1Year> Years { get; set; } = new List<Model1Year>();
    public int TargetAge { get; set; }
    public decimal? AmountAtTargetAge { get; set; }
}