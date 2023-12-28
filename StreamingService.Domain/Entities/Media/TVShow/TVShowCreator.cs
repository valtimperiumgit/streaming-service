namespace StreamingService.Domain.Media.TVShow;

public class TvShowCreator
{
    public TvShowCreator(Guid tvShowId, Guid creatorId)
    {
        Id = Guid.NewGuid();
        TvShowId = tvShowId;
        CreatorId = creatorId;
    }
    
    public Guid Id { get; set; }
    
    public Guid TvShowId { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Creator Creator { get; set; }
}