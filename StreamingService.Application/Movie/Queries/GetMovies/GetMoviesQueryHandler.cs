using StreamingService.Application.Core.Messaging;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.Movie.Queries.GetMovies;

public class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, List<Domain.Media.Movie.Movie>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<Domain.Media.Movie.Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _movieRepository.Get(cancellationToken);
    }
}