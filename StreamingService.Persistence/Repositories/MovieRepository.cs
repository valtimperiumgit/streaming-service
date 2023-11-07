using StreamingService.Domain.Media.Movie;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}