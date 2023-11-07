using EventReminder.Domain.Core.Primitives.Result;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Responses;
using StreamingService.Domain.Core.Primitives.Result;

namespace StreamingService.Application.Authentication.Commands.Login;

public sealed class LoginCommand : ICommand<Result<UserAuthenticationResponse>>
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get; }
    public string Password { get; }
}