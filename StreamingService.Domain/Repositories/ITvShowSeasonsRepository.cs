using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Repositories;

public interface ITvShowSeasonsRepository
{
    public Task<Season?> GetSeason(Guid tvShowId, int number, CancellationToken cancellationToken);
    public Task Insert(Season entity, CancellationToken cancellationToken);
}