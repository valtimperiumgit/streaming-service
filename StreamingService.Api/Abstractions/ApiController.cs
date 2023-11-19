using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Application.Core.Messaging;
using StreamingService.Domain.Core.Primitives.Result;
using Error = StreamingService.Domain.Core.Primitives.Error;

namespace StreamingService.Api.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender) => Sender = sender;

    private IActionResult HandleFailure(Result result)
    {
        return BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error));
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };

    protected string? GetClaimValueByProperty(string property)
    {
        return HttpContext.User.Claims
            .Where(claim => claim.Properties
                .FirstOrDefault().Value == property)
            .Select(claim => claim.Value)
            .FirstOrDefault();
    }

    protected async Task<IActionResult> DoCommand<T>(
        ICommand<Domain.Core.Primitives.Result.Result<T>> command,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
    }
    
    protected async Task<IActionResult> DoQuery<T>(
        IQuery<T> query,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(query, cancellationToken);
        return Ok(result);
    }
}