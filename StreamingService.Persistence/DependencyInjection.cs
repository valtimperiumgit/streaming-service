using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;
using StreamingService.Persistence.Repositories;

namespace StreamingService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey) ?? string.Empty;
        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<AppDbContext>(options => options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ITvShowsRepository, TvShowsRepository>();
        services.AddScoped<ITvShowsActorsRepository, TvShowsActorsRepository>();
        services.AddScoped<ITvShowsCreatorsRepository, TvShowsCreatorsRepository>();
        services.AddScoped<ITvShowsGenresRepository, TvShowsGenresRepository>();
        services.AddScoped<ITvShowSeasonsRepository, TvShowsSeasonsRepository>();
        
        return services;
    }
}