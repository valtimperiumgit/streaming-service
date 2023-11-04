using StreamingService.Domain.Media.Movie;
using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Media;

public class Creator
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<MovieCreator> MovieCreators { get; set; }
    
    public ICollection<TVShowCreator> TVShowCreators { get; set; }
}