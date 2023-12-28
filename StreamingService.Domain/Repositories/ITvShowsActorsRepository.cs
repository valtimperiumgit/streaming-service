using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Repositories;

public interface ITvShowsActorsRepository
{
    Task Insert(TvShowActor tvShowActor, CancellationToken cancellationToken);
}