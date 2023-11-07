using StreamingService.Domain.Media;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Api.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Genre> GetGenres(AppDbContext context) 
        => context.Genres;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Actor> GetActors(AppDbContext context) 
        => context.Actors;
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Creator> GetCreators(AppDbContext context) 
        => context.Creators;
}