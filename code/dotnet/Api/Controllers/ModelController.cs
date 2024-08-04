using Microsoft.AspNetCore.Mvc;
using PredictorLibrary.Model1;

namespace Api.Controllers;

// public class ExampleSchemaFilter : ISchemaFilter
// {
//     public void Apply(OpenApiSchema schema, SchemaFilterContext context)
//     {
//         if (context.Type == typeof(AccountSummaryRequest))
//         {
//             schema.Example = new OpenApiObject()
//             {
//                 ["accountCodes"] = new OpenApiArray { new OpenApiString("SIPP")},
//                 ["date"] = new OpenApiString("2024-10-30"),
//             };
//         }
//     }
// }

[ApiController]
[Route("api/[controller]")]
public class Model1Controller : ControllerBase
{
    private readonly ILogger<Model1Controller> _logger;
    private readonly Predictor _predictor;

    public Model1Controller(ILogger<Model1Controller> logger, Predictor predictor)
    {
        _logger = logger;
        _predictor = predictor;
    }

    [HttpPost]
    public Model1Prediction GetPrediction([FromBody] Model1Inputs inputs)
    {
        var prediction = _predictor.Generate(inputs);
        return prediction;
    }
}
