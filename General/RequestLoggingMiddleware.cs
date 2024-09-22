using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net.Http;

namespace General;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            // Log the incoming request details
            Log.Information("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Call the next middleware in the pipeline
            await _next(context);

            // Log after the response is handled
            Log.Information("Finished handling request.");
        }
        catch (Exception ex)
        {
            // Log the exception details
            Log.Error(ex, "An error occurred while processing the request.");

            // Optionally, you can handle the exception by returning a custom response
            context.Response.StatusCode = 500; // Internal Server Error
            await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
        }
    }
}
