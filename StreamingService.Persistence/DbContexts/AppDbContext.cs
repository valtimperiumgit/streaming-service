using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Admin;
using StreamingService.Domain.Media;
using StreamingService.Domain.Media.Movie;
using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.User;

namespace StreamingService.Persistence.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Creator> Creators { get; set; }
    
    public DbSet<MovieCreator> MovieCreators { get; set; }
    
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<MovieGenre> MovieGenres { get; set; }
    
    public DbSet<Season?> Seasons { get; set; }
    
    public DbSet<TvShow> TVShows { get; set; }
    
    public DbSet<TvShowActor> TVShowActors { get; set; }
    
    public DbSet<TvShowCreator> TVShowCreators { get; set; }

    public DbSet<TvShowGenre> TVShowGenres { get; set; }
    
    public DbSet<TvShowEpisode> TVShowEpisodes { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Actor> Actors { get; set; }
    
    public DbSet<MovieActor> MovieActors { get; set; }
    
    public DbSet<Admin> Admins { get; set; }
}