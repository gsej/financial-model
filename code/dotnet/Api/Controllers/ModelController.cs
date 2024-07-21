using Microsoft.AspNetCore.Mvc;

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
[Route("[controller]")]
public class ModelController : ControllerBase
{
    private readonly ILogger<ModelController> _logger;
  
    public ModelController(ILogger<ModelController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/hello")]
    public async Task<string> Hello()
    {
        return "hello";
    }
}
