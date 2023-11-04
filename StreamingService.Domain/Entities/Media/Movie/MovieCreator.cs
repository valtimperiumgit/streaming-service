namespace StreamingService.Domain.Media.Movie;

public class MovieCreator
{
    public Guid Id { get; set; }
    
    public Guid MovieId { get; set; }
    
    public Movie Movie { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public Creator Creator { get; set; }
}