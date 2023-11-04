namespace StreamingService.Domain.Media.TVShow;

public class TVShowActor
{
    public Guid Id { get; set; }
    
    public Guid TVShowId { get; set; }
    
    public Guid ActorId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Actor Actor { get; set; }
}