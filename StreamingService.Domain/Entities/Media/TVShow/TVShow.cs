using System.ComponentModel;
using StreamingService.Domain.User;

namespace StreamingService.Domain.Media.TVShow;

public class TvShow
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int MaturityRating { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string TrailerUrl { get; set; }
    
    public string LogoUrl { get; set; }
    
    public DateTime ReleaseDate { get; set; }

    [DefaultValue(1)]
    public int CountryId { get; set; }
    
    public ICollection<TVShowGenre> TVShowGenres { get; set; }
    
    public ICollection<TVShowActor> TVShowActors { get; set; }
    
    public ICollection<TVShowCreator> TVShowCreators { get; set; }
    
    public Country Country { get; set; }
}