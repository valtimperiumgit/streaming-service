using System.Windows.Input;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Requests;
using StreamingService.Contracts.Authentication.Responses;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Enums;
using StreamingService.Domain.User;

namespace StreamingService.Application.Authentication.Commands.Registration;

public sealed class RegistrationCommand : ICommand<Result<UserAuthenticationResponse>>
{
    public RegistrationCommand(RegistrationRequest request)
    {
        Email = request.Email;
        Name = request.Name;
        Password = request.Password;
        CountryId = request.CountryId;
        Sex = request.Sex;
        Age = request.Age;
    }

    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public int CountryId { get; set; }
    
    public Sex Sex { get; set; }
    
    public int Age { get; set; }
    
    public User CreateUser()
    {
        return new User(Guid.NewGuid(), Name, Email, Password, CountryId, Sex, Age);
    }
}