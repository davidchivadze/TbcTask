using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception
                _logger.LogError(ex, ex.Message);

                // Set the response status code to 500 (Internal Server Error)
                context.Response.StatusCode = 500;

                // Create and serialize the error response
                var errorResponse = new Response<object>(System.Net.HttpStatusCode.InternalServerError, "Internal Server Error: " + ex.Message);
                var jsonResponse = JsonConvert.SerializeObject(errorResponse);

                // Set the content type to JSON
                context.Response.ContentType = "application/json";

                // Write the JSON response to the response stream
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}