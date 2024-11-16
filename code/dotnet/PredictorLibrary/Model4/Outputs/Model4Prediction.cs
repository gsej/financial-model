namespace PredictorLibrary.Model4.Outputs;

public record Band(decimal Lower, decimal Upper, double Percentage);

public class Model4Prediction
{
    // Summary data will change, this is just so we can get something up on the screen

    public decimal Mean { get; set; }
    public decimal Minimum { get; set; }
    public decimal Maximum { get; set; }
    public List<Band> Bands { get; set; } = new();
    public List<Band> CumulativeBands { get; set; } = new();
    
    public List<Model4Iteration> Iterations { get; set; } = new();
}

