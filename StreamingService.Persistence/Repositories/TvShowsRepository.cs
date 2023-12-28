using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class TvShowsRepository : GenericRepository<TvShow>, ITvShowsRepository
{
    public TvShowsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}