using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Movie.Requests;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Media.TVShow;

namespace StreamingService.Application.TvShow.Commands.CreateTvShowSeason;

public class CreateTvShowSeasonCommand : ICommand<Result<Season>>
{
    public CreateTvShowSeasonCommand(CreateTvShowSeasonRequest request)
    {
        Title = request.Title;
        Number = request.Number;
        TvShowId = request.TvShowId;
    }

    public string Title { get; set; }
    public int Number { get; set; }
    public Guid TvShowId { get; set; }

    public Season CreateSeason()
    {
        return Season.CreateSeason(Guid.NewGuid(), Title, Number, TvShowId);
    }
}