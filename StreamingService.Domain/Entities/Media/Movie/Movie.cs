using System.ComponentModel;
using StreamingService.Domain.User;

namespace StreamingService.Domain.Media.Movie;

public class Movie
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int Duration { get; set; }
    
    public int MaturityRating { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string TrailerUrl { get; set; }
    
    public string LogoUrl { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    [DefaultValue(1)]
    public int CountryId { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; }
    
    public ICollection<MovieCreator> MovieCreators { get; set; }
    
    public ICollection<MovieActor> MovieActors { get; set; }
    
    public Country Country { get; set; }
}