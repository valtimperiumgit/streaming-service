using Microsoft.AspNetCore.Http;

namespace StreamingService.Application.Abstractions.Video;

public interface IVideoInfoHelper
{
    public int GetVideoDurationInMinutes(IFormFile videoFile);
}