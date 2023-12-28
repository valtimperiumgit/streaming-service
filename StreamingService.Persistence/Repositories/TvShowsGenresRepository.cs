using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class TvShowsGenresRepository : GenericRepository<TvShowGenre>, ITvShowsGenresRepository
{
    public TvShowsGenresRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}