using System.ComponentModel.DataAnnotations;
using StreamingService.Domain.Enums;

namespace StreamingService.Contracts.Authentication;

public class RegistrationRequest
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name length should be between 3 and 100.", MinimumLength = 3)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(50, ErrorMessage = "Password length should be between 5 and 50.", MinimumLength = 5)]
    public string Password { get; set; }

    [Required(ErrorMessage = "CountryId is required.")]
    public int CountryId { get; set; }

    [Required(ErrorMessage = "Sex is required.")]
    [EnumDataType(typeof(Sex), ErrorMessage = "Invalid value for Sex.")]
    public Sex Sex { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    [Range(18, 99, ErrorMessage = "Age should be between 18 and 99.")]
    public int Age { get; set; }
}