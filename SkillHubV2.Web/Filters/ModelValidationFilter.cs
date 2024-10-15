using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SkillsHubV2.Web.Filters;

public class ModelValidationActionFilter : IActionFilter
{
    public void OnActionExecuting (ActionExecutingContext context)
    {
        var modelState = context.ModelState;

        if (!modelState.IsValid)
        {
            var errorResponse = new ObjectResult(new
            {
                Success = false,
                Message = "Model validation failed",
                Errors = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
            })
            {
                StatusCode = 400
            };

            context.Result = errorResponse;
        }
    }

    public void OnActionExecuted (ActionExecutedContext context)
    {
        // Здесь можно добавить дополнительную логику, если нужно выполнить что-то после вызова метода
    }
}
