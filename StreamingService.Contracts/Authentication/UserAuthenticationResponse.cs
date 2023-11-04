using StreamingService.Contracts.User;

namespace StreamingService.Contracts.Authentication;

public class UserAuthenticationResponse
{
    public UserResponse User { get; set; }
    
    public string AccessToken { get; set; }
}