using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

public class SwaggerLocalizationHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema { Type = "string" },
            Description = "Language tag (e.g., en-US) for localization, (ka-GE,en-US)",
            Examples = new Dictionary<string, OpenApiExample>
            {
                {
                    "Default",
                    new OpenApiExample
                    {
                        Value = new OpenApiString("en-US")
                    }
                },
                 {
                    "Georgian",
                    new OpenApiExample
                    {
                        Value = new OpenApiString("ka-GE")
                    }
                },

            }
        });
    }
}