using StreamingService.Application.Core.Messaging;
using StreamingService.Domain.Core.Errors;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.TvShow.Commands.CreateTvShowSeason;

public class CreateTvShowSeasonCommandHandler : ICommandHandler<CreateTvShowSeasonCommand, Result<Domain.Media.TVShow.Season>>
{
    private readonly ITvShowSeasonsRepository _seasonsRepository;
    private readonly ITvShowsRepository _tvShowsRepository;

    public CreateTvShowSeasonCommandHandler(ITvShowSeasonsRepository seasonsRepository, ITvShowsRepository tvShowsRepository)
    {
        _seasonsRepository = seasonsRepository;
        _tvShowsRepository = tvShowsRepository;
    }

    public async Task<Result<Season>> Handle(CreateTvShowSeasonCommand command, CancellationToken cancellationToken)
    {
        var tvShow = await _tvShowsRepository.GetByProperty("Id", command.TvShowId, cancellationToken);

        if (tvShow is null)
        {
            return Result.Failure<Season>(DomainErrors.TvShow.TvShowNotFound);
        }
        
        var existingSeason = await _seasonsRepository.GetSeason(command.TvShowId, command.Number, cancellationToken);

        if (existingSeason is not null)
        {
            return Result.Failure<Season>(DomainErrors.Season.SeasonAlreadyExist);
        }

        var newSeason = command.CreateSeason();
        await _seasonsRepository.Insert(newSeason, cancellationToken);

        return newSeason;
    }
}