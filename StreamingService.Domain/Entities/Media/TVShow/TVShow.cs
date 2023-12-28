using System.ComponentModel;
using StreamingService.Domain.User;

namespace StreamingService.Domain.Media.TVShow;

public class TvShow
{
    public static TvShow CreateTvShow(
        Guid id,
        string title,
        string description,
        int maturityRating,
        DateTime releaseDate,
        int countryId)
    {
        return new TvShow
        {
            Id = id,
            Title = title,
            Description = description,
            MaturityRating = maturityRating,
            ReleaseDate = releaseDate,
            CountryId = countryId
        };
    }

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
    
    public ICollection<TvShowGenre> TVShowGenres { get; set; }
    
    public ICollection<TvShowActor> TVShowActors { get; set; }
    
    public ICollection<TvShowCreator> TVShowCreators { get; set; }
    
    public Country Country { get; set; }
}