using PredictorLibrary;
using Xunit.Abstractions;

namespace Tests;

public class ReturnRateCalculatorTests
    
{
    private readonly ITestOutputHelper _outputHelper;

    public ReturnRateCalculatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void aaaaaa()
    {
        var calculator = new ReturnRateCalculator(.05, .25);

        for (int i = 0; i < 100; i++)
        {
            var rate = calculator.GetReturnRate();
            _outputHelper.WriteLine(rate.ToString("F2"));
        }
    }
    //
    // [Fact]
    // public void Predict()
    // {
    //     
    //     
    //     
    //     
    //     
    //     var predicator = new Predictor();
    //
    //     var results = predicator.Predict(100);
    //
    //     foreach (var result in results.Order())
    //     {
    //         _outputHelper.WriteLine(result.ToString("F2"));
    //     }
    // } 
}