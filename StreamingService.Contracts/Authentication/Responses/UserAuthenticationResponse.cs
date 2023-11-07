using StreamingService.Contracts.User;

namespace StreamingService.Contracts.Authentication.Responses;

public class UserAuthenticationResponse
{
    public UserResponse User { get; set; }
    
    public string Token { get; set; }
}