using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PredictorLibrary.Model1;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Model1Controller : ControllerBase
{
    private readonly Predictor _predictor;

    public Model1Controller(Predictor predictor)
    {
        _predictor = predictor;
    }

    [HttpPost]
    public Model1Prediction GetPrediction([FromBody] Model1Inputs inputs)
    {
        var prediction = _predictor.Generate(inputs);
        return prediction;
    }
    
    public class Model1Example : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Model1Inputs))
            {
                schema.Example = new OpenApiObject()
                {
                    ["startYear"] = new OpenApiInteger(2025),
                    ["ageAtStart"] = new OpenApiInteger(30),
                    ["endYear"] = new OpenApiInteger(2065),
                    ["amountAtStart"] = new OpenApiInteger(100000),
                    ["annualContribution"] = new OpenApiInteger(12000),
                    ["meanAnnualReturn"] = new OpenApiDouble(0.05),
                    ["targetAge"] = new OpenApiInteger(67),
                };
            }
        }
    }
}
