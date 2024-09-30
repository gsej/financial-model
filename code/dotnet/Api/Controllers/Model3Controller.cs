using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PredictorLibrary;
using PredictorLibrary.Model3;
using PredictorLibrary.Model3.Inputs;
using PredictorLibrary.Model3.Outputs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Model3Controller : ControllerBase
{
    [HttpPost]
    public Model3Prediction GetPrediction([FromBody] Model3Inputs inputs)
    {
        var predictor = new Model3Predictor();
        var rateOfReturnCalculator = new ReturnRateCalculator();
        var prediction = predictor.Generate(rateOfReturnCalculator, inputs);
        return prediction;
    }

    public class Model3Example : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Model3Inputs))
            {
                schema.Example = new OpenApiObject()
                {
                    ["startYear"] = new OpenApiInteger(2025),
                    ["ageAtStart"] = new OpenApiInteger(30),
                    ["endYear"] = new OpenApiInteger(2065),
                    ["amountAtStart"] = new OpenApiInteger(100000),
                    ["annualContribution"] = new OpenApiInteger(12000),
                    ["allocations"] = new OpenApiArray()
                    {
                        new OpenApiObject()
                        {
                            ["name"] = new OpenApiString("Growth"),
                            ["proportion"] = new OpenApiDouble(0.8),
                            ["meanAnnualReturn"] = new OpenApiDouble(0.05),
                            ["standardDeviation"] = new OpenApiDouble(0.25),

                        },
                        new OpenApiObject()
                        {
                            ["name"] = new OpenApiString("Minimal Risk"),
                            ["proportion"] = new OpenApiDouble(0.2),
                            ["meanAnnualReturn"] = new OpenApiDouble(0.01),
                            ["standardDeviation"] = new OpenApiDouble(0),
                        },
                    },
                    ["targetAge"] = new OpenApiInteger(67),
                };
            }
        }
    }
}