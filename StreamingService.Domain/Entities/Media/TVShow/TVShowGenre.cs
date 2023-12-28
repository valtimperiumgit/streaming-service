namespace StreamingService.Domain.Media.TVShow;

public class TvShowGenre
{
    public TvShowGenre(Guid tvShowId, Guid genreId)
    {
        Id = Guid.NewGuid();
        TvShowId = tvShowId;
        GenreId = genreId;
    }
    
    public Guid Id { get; set; }
    
    public Guid TvShowId { get; set; }
    
    public Guid GenreId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Genre Genre { get; set; }
}