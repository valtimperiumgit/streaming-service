using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class TvShowsSeasonsRepository : GenericRepository<Season>, ITvShowSeasonsRepository
{
    public TvShowsSeasonsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Season?> GetSeason(Guid tvShowId, int number, CancellationToken cancellationToken)
    {
        return DbContext.Seasons
            .FirstOrDefaultAsync(season =>
                season != null 
                && season.TVShowId == tvShowId
                && season.Number == number, cancellationToken: cancellationToken);
    }
}