using StreamingService.Domain.Media.Movie;

namespace StreamingService.Domain.Repositories;

public interface IMovieRepository
{
    public Task Insert(Movie entity, CancellationToken cancellationToken);

    public Task<List<Movie>> Get(CancellationToken cancellationToken);
}