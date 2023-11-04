namespace StreamingService.Domain.Media.Movie;

public class MovieGenre
{
    public Guid Id { get; set; }
    
    public Guid MovieId { get; set; }
    
    public Movie Movie { get; set; }

    public Guid GenreId { get; set; }
    
    public Genre Genre { get; set; }
}