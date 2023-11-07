using System.Security.Claims;
using StreamingService.Domain.User;

namespace StreamingService.Application.Abstractions.Authentication;

public static class Claims
{
    public static Claim[] ForUser(User user)
    {
        return new Claim[]
        {
            new("userId", user.Id.ToString()),
            new("email", user.Email),
            new(ClaimTypes.Role, "User")
        };
    }
    
    public static Claim[] ForAdmin(Domain.Admin.Admin admin)
    {
        return new Claim[]
        {
            new("userId", admin.Id.ToString()),
            new("email", admin.Email),
            new(ClaimTypes.Role, "Admin")
        };
    }
}