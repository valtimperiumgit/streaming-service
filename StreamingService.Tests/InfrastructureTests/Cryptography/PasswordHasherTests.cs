using FluentAssertions;
using StreamingService.Infrastructure.Cryptography;

namespace StreamingService.Tests.InfrastructureTests.Cryptography;

public static class PasswordHasherTests
{
    [Theory]
    [InlineData("password", "5F4DCC3B5AA765D61D8327DEB882CF99")]
    public static void PasswordHasher_Hash_ReturnHashedPassword(string password, string hashedPassword)
    {
        //Arrange
        PasswordHasher passwordHasher = new PasswordHasher();

        //Act
        var result = passwordHasher.Hash(password);

        //Assert
        result.Should().Be(hashedPassword);
    }
}