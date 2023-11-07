
using StreamingService.Application.Abstractions.Authentication;
using StreamingService.Application.Core.Cryptography;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Responses;
using StreamingService.Contracts.User;
using StreamingService.Domain.Core.Errors;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Repositories;
using StreamingService.Domain.User;

namespace StreamingService.Application.Authentication.Commands.Login;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, Result<UserAuthenticationResponse>>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    
    public LoginCommandHandler(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<UserAuthenticationResponse>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByProperty(nameof(User.Email), request.Email, cancellationToken);

        if (user is null || _passwordHasher.Hash(request.Password) != user.Password)
        {
            return Result.Failure<UserAuthenticationResponse>(DomainErrors.Authentication.InvalidEmailOrPassword);
        }

        return Result.Success(new UserAuthenticationResponse
        {
            User = new UserResponse(user),
            Token = _jwtProvider.Create(Claims.ForUser(user))
        });
    }
}