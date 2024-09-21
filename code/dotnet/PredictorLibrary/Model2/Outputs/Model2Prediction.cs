namespace PredictorLibrary.Model2.Outputs;

public class Model2Prediction
{
    public List<Model2Year> Years { get; set; } = new List<Model2Year>();
    public int TargetAge { get; set; }
    public decimal? AmountAtTargetAge { get; set; }
}