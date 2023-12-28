using StreamingService.Domain.Media.Movie;
using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Media;

public class Genre
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<MovieGenre> MovieGenres { get; set; }
    
    public ICollection<TvShowGenre> TVShowGenres { get; set; }
}