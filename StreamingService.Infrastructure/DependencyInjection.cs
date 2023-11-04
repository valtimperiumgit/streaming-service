using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StreamingService.Application.Abstractions.Authentication;
using StreamingService.Application.Abstractions.Authentication.Settings;
using StreamingService.Application.Core.Cryptography;
using StreamingService.Infrastructure.Authentication;
using StreamingService.Infrastructure.Cryptography;

namespace StreamingService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
            });
        
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));
        
        services.AddScoped<IJwtProvider, JwtProvider>();
        
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
}