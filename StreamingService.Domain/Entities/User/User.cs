using StreamingService.Domain.Enums;

namespace StreamingService.Domain.User;

public class User
{
    public User(
        Guid id,
        string name,
        string email,
        string password,
        int countryId,
        Sex sex,
        int age)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        CountryId = countryId;
        Sex = sex;
        Age = age;
    }

    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public int CountryId { get; set; }
    
    public Sex Sex { get; set; }
    
    public int Age { get; set; }

    public Country Country { get; set; }
}