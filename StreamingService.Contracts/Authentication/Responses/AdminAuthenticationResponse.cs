using StreamingService.Domain.Admin;

namespace StreamingService.Contracts.Authentication;

public class AdminAuthenticationResponse
{
    public Admin Admin { get; set; }
    
    public string Token { get; set; }
}