using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class TvShowsActorsRepository : GenericRepository<TvShowActor>, ITvShowsActorsRepository
{
    public TvShowsActorsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}