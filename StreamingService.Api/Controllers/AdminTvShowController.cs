using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Abstractions;
using StreamingService.Application.TvShow.Commands.CreateTvShow;
using StreamingService.Application.TvShow.Commands.CreateTvShowSeason;
using StreamingService.Contracts.Movie.Requests;

namespace StreamingService.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("admin/tv-shows")]
public class AdminTvShowController : ApiController
{
    public AdminTvShowController(ISender sender) : base(sender)
    {
    }
    
    [HttpPost]
    public Task<IActionResult> CreateTvShow(CreateTvShowRequest request, CancellationToken cancellationToken)
    {
        var createTvShowCommand = new CreateTvShowCommand(request);
        return DoCommand(createTvShowCommand, cancellationToken);
    }
    
    [HttpPost]
    public Task<IActionResult> CreateTvShowSeason(CreateTvShowSeasonRequest request, CancellationToken cancellationToken)
    {
        var createTvShowSeasonCommand = new CreateTvShowSeasonCommand(request);
        return DoCommand(createTvShowSeasonCommand, cancellationToken);
    }
    
    [HttpPost]
    public Task<IActionResult> CreateTvShowEpisode(CreateTvShowRequest request, CancellationToken cancellationToken)
    {
        var createTvShowCommand = new CreateTvShowCommand(request);
        return DoCommand(createTvShowCommand, cancellationToken);
    }
}