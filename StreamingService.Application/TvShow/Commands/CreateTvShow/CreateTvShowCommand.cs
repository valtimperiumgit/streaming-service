using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Movie.Requests;
using StreamingService.Domain.Core.Primitives.Result;

namespace StreamingService.Application.TvShow.Commands.CreateTvShow;

public class CreateTvShowCommand : ICommand<Result<Domain.Media.TVShow.TvShow>>
{
    public CreateTvShowCommand(CreateTvShowRequest request)
    {
        Title = request.Title;
        Description = request.Description;
        MaturityRating = request.MaturityRating;
        Image = request.Image;
        Trailer = request.Trailer;
        Logo = request.Logo;
        ReleaseDate = request.ReleaseDate;
        Genres = request.Genres;
        Actors = request.Actors;
        Creators = request.Creators;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public int MaturityRating { get; set; }
    public IFormFile Image { get; set; }
    public IFormFile Trailer { get; set; }
    public int CountryId { get; set; }
    public IFormFile Logo { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Guid> Genres { get; set; }
    public List<Guid> Actors { get; set; }
    public List<Guid> Creators { get; set; }

    public Domain.Media.TVShow.TvShow CreateTvShow()
    {
        return Domain.Media.TVShow.TvShow.CreateTvShow(
            Guid.NewGuid(), 
            Title,
            Description,
            MaturityRating,
            ReleaseDate,
            CountryId);
    }
}