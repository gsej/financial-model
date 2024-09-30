namespace PredictorLibrary.Model3.Outputs;

public class Model3Prediction
{
    public List<Model3Year> Years { get; set; } = new List<Model3Year>();
    public int TargetAge { get; set; }
    public decimal? AmountAtTargetAge { get; set; }
}