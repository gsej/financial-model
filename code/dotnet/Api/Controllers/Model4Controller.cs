using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PredictorLibrary;
using PredictorLibrary.Model4;
using PredictorLibrary.Model4.Inputs;
using PredictorLibrary.Model4.Outputs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Model4Controller : ControllerBase
{
    [HttpPost]
    public Model4Prediction GetPrediction([FromBody] Model4Inputs inputs)
    {
        var predictor = new Model4Predictor();
        var rateOfReturnCalculator = new ReturnRateCalculator();
        var prediction = predictor.Generate(rateOfReturnCalculator, inputs);
        return prediction;
    }

    public class Model4Example : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Model4Inputs))
            {
                schema.Example = new OpenApiObject()
                {
                    ["ageAtStart"] = new OpenApiInteger(30),
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
                    ["iterations"] = new OpenApiInteger(1000),
                };
            }
        }
    }
}