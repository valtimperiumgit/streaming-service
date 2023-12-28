namespace StreamingService.Domain.Media.TVShow;

public class Season
{
    public static Season CreateSeason(Guid id, string title, int number, Guid tvShowId)
    {
        return new Season
        {
            Id = id,
            Title = title,
            Number = number,
            TVShowId = tvShowId
        };
    }

    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public int Number { get; set; }
    
    public Guid TVShowId { get; set; }
    
    public TvShow TVShow { get; set; }
    
    public ICollection<TvShowEpisode> Episodes { get; set; }
}