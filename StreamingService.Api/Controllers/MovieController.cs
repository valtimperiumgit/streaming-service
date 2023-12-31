using MediatR;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Api.Abstractions;
using StreamingService.Application.Movie.Commands.CreateMovie;
using StreamingService.Application.Movie.Queries.GetMovies;
using StreamingService.Contracts.Movie.Requests;

namespace StreamingService.Api.Controllers;

[Route("admin/movies")]
public class MovieController : ApiController
{
    public MovieController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var createMovieCommand = new CreateMovieCommand(request);
        return DoCommand(createMovieCommand, cancellationToken);
    }
    
    [HttpGet]
    public Task<IActionResult> GetMovies(CancellationToken cancellationToken)
    {
        return DoQuery(new GetMoviesQuery(), cancellationToken);
    }
}