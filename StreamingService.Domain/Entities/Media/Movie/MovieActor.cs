namespace StreamingService.Domain.Media.Movie;

public class MovieActor
{
    public Guid Id { get; set; }
    
    public Guid ActorId { get; set; }
    
    public Guid MovieId { get; set; }
    
    public Actor Actor { get; set; }
    
    public Domain.Media.Movie.Movie Movie { get; set; }
}