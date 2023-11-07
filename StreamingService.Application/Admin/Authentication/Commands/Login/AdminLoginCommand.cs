using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Domain.Core.Primitives.Result;

namespace StreamingService.Application.Admin.Authentication.Commands.Login;

public class AdminLoginCommand : ICommand<Result<AdminAuthenticationResponse>>
{
    public AdminLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get; }
    public string Password { get; }
}