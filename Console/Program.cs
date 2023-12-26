using Microsoft.Extensions.Configuration;
using PredictorLibrary;

namespace Console;

class Program
{
    static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json")
            .AddUserSecrets<Program>();
            
        var config = configurationBuilder.Build();

        var modelParameters = new ModelParameters();
       config.Bind("ModelParameters", modelParameters);

       var predictor = new Predictor(modelParameters);
       var predictions = predictor.Predict(1000);

       foreach (var predication in predictions)
       {
           System.Console.WriteLine(predication.ToString("F0"));
       }
    }
}