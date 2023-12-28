using StreamingService.Domain.Media.Movie;
using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Media;

public class Actor
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<MovieActor> MovieActors { get; set; }
    
    public ICollection<TvShowActor> TVShowActors { get; set; }
}