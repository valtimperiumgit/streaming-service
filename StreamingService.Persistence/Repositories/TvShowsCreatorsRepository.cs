using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class TvShowsCreatorsRepository : GenericRepository<TvShowCreator>, ITvShowsCreatorsRepository
{
    public TvShowsCreatorsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}