using StreamingService.Application.Abstractions.Authentication;
using StreamingService.Application.Core.Cryptography;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Responses;
using StreamingService.Contracts.User;
using StreamingService.Domain.Core.Errors;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.Authentication.Commands.Registration;

public class RegistrationCommandHandler : ICommandHandler<RegistrationCommand, Result<UserAuthenticationResponse>>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    
    public RegistrationCommandHandler(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<Result<UserAuthenticationResponse>> Handle(
        RegistrationCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByProperty(nameof(request.Email), request.Email, cancellationToken);

        if (existingUser is not null)
        { 
            return Result.Failure<UserAuthenticationResponse>(DomainErrors.User.UserAlreadyExist);
        }

        var newUser = request.CreateUser();
        newUser.Password = _passwordHasher.Hash(newUser.Password);

        await _userRepository.Insert(newUser, cancellationToken);
        
        return Result.Success(new UserAuthenticationResponse
        {
            User = new UserResponse(newUser),
            Token = _jwtProvider.Create(Claims.ForUser(newUser))
        });
    }
}