using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
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

        var finalModel = predictor.Model;

        var years = finalModel.Years;
        
        
        using (var writer = new StreamWriter("model.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture, leaveOpen: false))
        {
            csv.Context.RegisterClassMap<FiguresForYearMap>();  
            csv.WriteRecords(years);
            
//            csv.WriteRecords(predictions);
            
            
        }

        
    
        //
        // foreach (var predication in predictions)
        // {
        //     System.Console.WriteLine(predication.ToString("F0"));
        // }
        //
        // foreach (var y in predictor.Y)


    }
}