using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Abstractions;
using StreamingService.Application.Authentication.Commands.Login;
using StreamingService.Application.Authentication.Commands.Registration;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Requests;

namespace StreamingService.Api.Controllers;

[Route("authentication")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender) : base(sender) { }
    
    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var loginCommand = new LoginCommand(request.Email, request.Password);
        return DoCommand(loginCommand, cancellationToken);
    }
    
    [HttpPost("registration")]
    public Task<IActionResult> Registration([FromBody] RegistrationRequest request, CancellationToken cancellationToken)
    {
        var registrationCommand = new RegistrationCommand(request);
        return DoCommand(registrationCommand, cancellationToken);
    }
}