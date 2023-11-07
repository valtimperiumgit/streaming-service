using StreamingService.Application.Abstractions.Storeges;
using StreamingService.Application.Abstractions.Video;
using StreamingService.Application.Core.Messaging;
using StreamingService.Domain.Core.Primitives.Result;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.Movie.Commands.CreateMovie;

public class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand, Result<Domain.Media.Movie.Movie>>
{
    private readonly IBucket _bucket;
    private readonly IVideoInfoHelper _videoInfoHelper;
    private readonly IMovieRepository _movieRepository;

    public CreateMovieCommandHandler(
        IBucket bucket,
        IVideoInfoHelper videoInfoHelper,
        IMovieRepository movieRepository)
    {
        _bucket = bucket;
        _videoInfoHelper = videoInfoHelper;
        _movieRepository = movieRepository;
    }

    public async Task<Result<Domain.Media.Movie.Movie>> Handle(
        CreateMovieCommand request,
        CancellationToken cancellationToken)
    {
        var movieDuration = _videoInfoHelper.GetVideoDurationInMinutes(request.Video);
        var newMovie = request.CreateMovie(movieDuration);

        await EnrichMovieWithContentUrls(newMovie, request);

        await _movieRepository.Insert(newMovie, cancellationToken);

        return newMovie;
    }

    private async Task EnrichMovieWithContentUrls(Domain.Media.Movie.Movie movie, CreateMovieCommand request)
    {
        var movieFolder = $"movies/{movie.Id.ToString()}";
        await _bucket.CreateFolder(movieFolder);

        movie.VideoUrl = await _bucket.UploadFileAsync(request.Video.OpenReadStream(), $"{movieFolder}/movie");
        movie.TrailerUrl = await _bucket.UploadFileAsync(request.Trailer.OpenReadStream(), $"{movieFolder}/trailer");
        movie.LogoUrl = await _bucket.UploadFileAsync(request.Logo.OpenReadStream(), $"{movieFolder}/logo");
        movie.ImageUrl = await _bucket.UploadFileAsync(request.Image.OpenReadStream(), $"{movieFolder}/image");
    }
}