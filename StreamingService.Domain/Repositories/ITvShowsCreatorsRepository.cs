using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Repositories;

public interface ITvShowsCreatorsRepository
{
    Task Insert(TvShowCreator tvShowCreator, CancellationToken cancellationToken);
}