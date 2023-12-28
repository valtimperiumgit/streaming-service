namespace StreamingService.Domain.Media.TVShow;

public class TvShowActor
{
    public TvShowActor(Guid tvShowId, Guid actorId)
    {
        Id = Guid.NewGuid();
        TvShowId = tvShowId;
        ActorId = actorId;
    }
    
    public Guid Id { get; set; }
    
    public Guid TvShowId { get; set; }
    
    public Guid ActorId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Actor Actor { get; set; }
}