namespace StreamingService.Domain.Media.TVShow;

public class TVShowCreator
{
    public Guid Id { get; set; }
    
    public Guid TVShowId { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public Domain.Media.TVShow.TvShow TVShow { get; set; }
    
    public Creator Creator { get; set; }
}