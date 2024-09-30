namespace PredictorLibrary;

public interface IReturnRateCalculator
{
    decimal GetReturnRate(decimal mean, decimal standardDeviation);
}