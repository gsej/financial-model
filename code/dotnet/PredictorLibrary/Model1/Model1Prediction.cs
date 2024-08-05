namespace PredictorLibrary.Model1;

public class Model1Prediction
{
    public List<Year> Years { get; set; } = new List<Year>();
    public int TargetAge { get; set; }
    public decimal? AmountAtTargetAge { get; set; }
}