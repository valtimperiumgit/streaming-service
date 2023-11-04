namespace StreamingService.Domain.Media.TVShow;

public class TVShowEpisode
{
    public Guid Id { get; set; }
    
    public int Number { get; set; }
    
    public string Title { get; set; }
    
    public Guid SeasonId { get; set; }
    
    public Season Season { get; set; }

    public int Duration { get; set; }
}