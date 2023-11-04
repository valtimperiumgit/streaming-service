using StreamingService.Domain.Core.Primitives;

namespace StreamingService.Domain.Core.Errors;

public static class DomainErrors
{
    public static class Authentication
    {
        public static Error InvalidEmailOrPassword => new(
            "Authentication.InvalidEmailOrPassword",
            "The specified email or password are incorrect.");
    }
    
    public static class User
    {
        public static Error UserAlreadyExist => new(
            "User.UserAlreadyExist",
            "The user with specified email already exist.");
    }
}