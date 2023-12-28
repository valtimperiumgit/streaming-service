using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Domain.Repositories;

public interface ITvShowsRepository
{
    public Task Insert(TvShow entity, CancellationToken cancellationToken);
    public Task<TvShow?> GetByProperty(string propertyName, object value, CancellationToken cancellationToken);
}