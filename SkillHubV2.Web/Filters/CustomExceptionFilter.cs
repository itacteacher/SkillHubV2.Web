using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SkillsHubV2.Web.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    private readonly ILogger<CustomExceptionFilter> _logger;

    public CustomExceptionFilter (ILogger<CustomExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException (ExceptionContext context)
    {
        var exception = context.Exception;

        Console.WriteLine($"Exception occurred: {exception.Message}");

        context.Result = new ContentResult
        {
            Content = "An unexpected error occurred. Please try again later.",
            ContentType = "text/plain",
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
