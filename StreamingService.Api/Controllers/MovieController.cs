using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Abstractions;
using StreamingService.Application.Movie.Commands.CreateMovie;
using StreamingService.Contracts.Movie.Requests;

namespace StreamingService.Api.Controllers;

[Route("admin/movies")]
public class MovieController : ApiController
{
    public MovieController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var createMovieCommand = new CreateMovieCommand(request);
        return await DoCommand(createMovieCommand, cancellationToken);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var createMovieCommand = new CreateMovieCommand(request);
        return await DoCommand(createMovieCommand, cancellationToken);
    }
}