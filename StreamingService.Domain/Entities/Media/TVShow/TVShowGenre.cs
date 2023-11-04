namespace StreamingService.Domain.Media.TVShow;

public class TVShowGenre
{
    public Guid Id { get; set; }
    
    public Guid TVShowId { get; set; }
    
    public Guid GenreId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Genre Genre { get; set; }
}