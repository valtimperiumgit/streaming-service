using StreamingService.Application.Abstractions.Storeges;
using StreamingService.Application.Core.Messaging;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Media.TVShow;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.TvShow.Commands.CreateTvShow;

public class CreateTvShowCommandHandler : ICommandHandler<CreateTvShowCommand, Result<Domain.Media.TVShow.TvShow>>
{
    private readonly ITvShowsRepository _tvShowsRepository;
    private readonly ITvShowsActorsRepository _tvShowsActorsRepository;
    private readonly ITvShowsCreatorsRepository _tvShowsCreatorsRepository;
    private readonly ITvShowsGenresRepository _tvShowsGenresRepository;
    private readonly IBucket _bucket;

    public CreateTvShowCommandHandler(
        ITvShowsRepository tvShowsRepository,
        IBucket bucket,
        ITvShowsActorsRepository tvShowsActorsRepository, 
        ITvShowsCreatorsRepository tvShowsCreatorsRepository,
        ITvShowsGenresRepository tvShowsGenresRepository)
    {
        _tvShowsRepository = tvShowsRepository;
        _bucket = bucket;
        _tvShowsActorsRepository = tvShowsActorsRepository;
        _tvShowsCreatorsRepository = tvShowsCreatorsRepository;
        _tvShowsGenresRepository = tvShowsGenresRepository;
    }

    public async Task<Result<Domain.Media.TVShow.TvShow>> Handle(CreateTvShowCommand command, CancellationToken cancellationToken)
    {
        var newTvShow = command.CreateTvShow();
        await EnrichTvShowWithContentUrls(newTvShow, command);

        await _tvShowsRepository.Insert(newTvShow, cancellationToken);

        if (command.Actors.Count > 0)
        {
            foreach (var actorId in command.Actors)
            {
                await _tvShowsActorsRepository.Insert(new TvShowActor(newTvShow.Id, actorId), cancellationToken);
            }
        }
        
        if (command.Genres.Count > 0)
        {
            foreach (var genreId in command.Genres)
            {
                await _tvShowsGenresRepository.Insert(new TvShowGenre(newTvShow.Id, genreId), cancellationToken);
            }
        }

        if (command.Creators.Count <= 0)
        {
            return newTvShow;
        }
        
        foreach (var creatorId in command.Creators)
        {
            await _tvShowsCreatorsRepository.Insert(new TvShowCreator(newTvShow.Id, creatorId), cancellationToken);
        }

        return newTvShow;
    }
    
    private async Task EnrichTvShowWithContentUrls(Domain.Media.TVShow.TvShow tvShow, CreateTvShowCommand command)
    {
        var tvShowFolder = $"tvShows/{tvShow.Id.ToString()}";
        await _bucket.CreateFolder(tvShowFolder);
        
        tvShow.TrailerUrl = await _bucket.UploadFileAsync(command.Trailer.OpenReadStream(), $"{tvShowFolder}/trailer");
        tvShow.LogoUrl = await _bucket.UploadFileAsync(command.Logo.OpenReadStream(), $"{tvShowFolder}/logo");
        tvShow.ImageUrl = await _bucket.UploadFileAsync(command.Image.OpenReadStream(), $"{tvShowFolder}/image");
    }
}