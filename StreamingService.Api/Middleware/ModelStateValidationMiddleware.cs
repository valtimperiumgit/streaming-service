using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace StreamingService.Api.Middleware;

public class ModelStateValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IActionContextAccessor _actionContextAccessor;

    public ModelStateValidationMiddleware(RequestDelegate next, IActionContextAccessor actionContextAccessor)
    {
        _next = next;
        _actionContextAccessor = actionContextAccessor;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (IsModelProcessable())
        {
            await context.Response.WriteAsync(GetProblemDetailsResponse(context));
            return;
        }

        await _next(context);
    }
    
    private bool IsModelProcessable()
    {
        return _actionContextAccessor.ActionContext?.ModelState != null &&
               !_actionContextAccessor.ActionContext.ModelState.IsValid;
    }

    private string GetProblemDetailsResponse(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";
            
        var problemDetails = new ValidationProblemDetails(_actionContextAccessor.ActionContext!.ModelState);
        return JsonSerializer.Serialize(problemDetails);
    }
}