using StreamingService.Application.Abstractions.Authentication;
using StreamingService.Application.Core.Cryptography;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Domain.Core.Errors;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.Admin.Authentication.Commands.Login;

public class AdminLoginCommandHandler : ICommandHandler<AdminLoginCommand, Result<AdminAuthenticationResponse>>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    
    public AdminLoginCommandHandler(
        IAdminRepository adminRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _adminRepository = adminRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<Result<AdminAuthenticationResponse>> Handle(
        AdminLoginCommand request,
        CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetByProperty(nameof(request.Email), request.Email, cancellationToken);

        if (admin is null || _passwordHasher.Hash(request.Password) != admin.Password)
        {
            return Result.Failure<AdminAuthenticationResponse>(DomainErrors.Authentication.InvalidEmailOrPassword);
        }
        
        return Result.Success(new AdminAuthenticationResponse
        {
            Admin = admin,
            Token = _jwtProvider.Create(Claims.ForAdmin(admin))
        });
    }
}