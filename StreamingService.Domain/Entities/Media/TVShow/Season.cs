namespace StreamingService.Domain.Media.TVShow;

public class Season
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public int Number { get; set; }
    
    public Guid TVShowId { get; set; }
    
    public TvShow TVShow { get; set; }
    
    public ICollection<TVShowEpisode> Episodes { get; set; }
}