using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Controllers;
using StreamingService.Contracts.Authentication;
using StreamingService.Contracts.Authentication.Requests;
using StreamingService.Domain.Core.Primitives.Result;

namespace StreamingService.Tests.Api.Controllers;

public class AuthenticationControllerTests
{
    private readonly AuthenticationController _controller;
    
    public AuthenticationControllerTests()
    {
        var sender = A.Fake<ISender>();

        _controller = new AuthenticationController(sender);
    }
    
    [Fact]
    public async void AuthenticationController_Login_ReturnOk()
    {
        //Arrange
        LoginRequest request = new LoginRequest
        {
            Email = "someemail@gmail.com",
            Password = "password123"
        };

        CancellationToken cancellationToken = new CancellationToken();
        
        //Act
        var result = await _controller.Login(request, cancellationToken);

        //Assert

        result.Should().BeOfType<IActionResult>();
        result.Should().BeOfType<IActionResult>();
    }
}