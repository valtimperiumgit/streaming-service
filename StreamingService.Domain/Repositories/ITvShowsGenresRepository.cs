using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Repositories;

public interface ITvShowsGenresRepository
{
    Task Insert(TvShowGenre tvShowGenre, CancellationToken cancellationToken);
}