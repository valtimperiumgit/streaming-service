using StreamingService.Domain.Admin;

namespace StreamingService.Contracts.Authentication.Responses;

public class AdminAuthenticationResponse
{
    public Admin Admin { get; set; }
    
    public string Token { get; set; }
}