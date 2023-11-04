using System.Security.Claims;

namespace StreamingService.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    public string Create(Claim[] claims);
}