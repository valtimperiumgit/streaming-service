using StreamingService.Domain.Enums;
using StreamingService.Domain.User;

namespace StreamingService.Contracts.User;

public class UserResponse
{
    public UserResponse(Domain.User.User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        CountryId = user.CountryId;
        Sex = user.Sex;
        Age = user.Age;
        Country = user.Country;
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public int CountryId { get; set; }
    
    public Sex Sex { get; set; }
    
    public int Age { get; set; }

    public Country Country { get; set; }
}