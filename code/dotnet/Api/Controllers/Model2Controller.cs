using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PredictorLibrary.Model2;
using PredictorLibrary.Model2.Inputs;
using PredictorLibrary.Model2.Outputs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Model2Controller : ControllerBase
{
    private readonly Model2Predictor _model2Predictor;

    public Model2Controller(Model2Predictor model1Predictor)
    {
        _model2Predictor = model1Predictor;
    }

    [HttpPost]
    public Model2Prediction GetPrediction([FromBody] Model2Inputs inputs)
    {
        var prediction = _model2Predictor.Generate(inputs);
        return prediction;
    }
    
    public class Model2Example : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Model2Inputs))
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