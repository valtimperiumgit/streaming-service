using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Abstractions;
using StreamingService.Application.Admin.Authentication.Commands.Login;
using StreamingService.Application.Authentication.Commands.Login;
using StreamingService.Contracts.Authentication;

namespace StreamingService.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("admin/authentication")]
public class AdminAuthenticationController : ApiController
{
    public AdminAuthenticationController(ISender sender) : base(sender)
    {
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var adminLoginCommand = new AdminLoginCommand(request.Email, request.Password);
        return await DoCommand(adminLoginCommand, cancellationToken);
    }
}