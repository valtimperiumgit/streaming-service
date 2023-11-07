using Microsoft.AspNetCore.Http;
using StreamingService.Application.Core.Messaging;
using StreamingService.Contracts.Movie.Requests;
using StreamingService.Domain.Core.Primitives.Result;

namespace StreamingService.Application.Movie.Commands.CreateMovie;

public class CreateMovieCommand : ICommand<Result<Domain.Media.Movie.Movie>>
{
    public CreateMovieCommand(CreateMovieRequest request)
    {
        Title = request.Title;
        Description = request.Description;
        MaturityRating = request.MaturityRating;
        Image = request.Image;
        Video = request.Video;
        Trailer = request.Trailer;
        Logo = request.Logo;
        ReleaseDate = request.ReleaseDate;
        CountryId = request.CountryId;
        Genres = request.Genres;
        Actors = request.Actors;
        Creators = request.Creators;
    }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int MaturityRating { get; set; }

    public IFormFile Image{ get; set; }

    public IFormFile Video { get; set; }
    
    public IFormFile Trailer { get; set; }
    
    public IFormFile Logo { get; set; }
    
    public DateTime ReleaseDate { get; set; }

    public int CountryId { get; set; }

    public List<Guid> Genres { get; set; }

    public List<Guid> Actors { get; set; }

    public List<Guid> Creators { get; set; }

    public Domain.Media.Movie.Movie CreateMovie(int duration)
    {
        return new Domain.Media.Movie.Movie(Guid.NewGuid(), Title, Description, duration, MaturityRating, ReleaseDate, CountryId);
    }
    
}