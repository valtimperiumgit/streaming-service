using MediaInfo;
using Microsoft.AspNetCore.Http;
using StreamingService.Application.Abstractions.Video;

namespace StreamingService.Infrastructure.Video;

public class VideoInfoHelper : IVideoInfoHelper
{
    public int GetVideoDurationInMinutes(IFormFile videoFile)
    {
        var tempFilePath = Path.GetTempFileName();
        using (var stream = new FileStream(tempFilePath, FileMode.Create))
        {
            videoFile.CopyTo(stream);
        }

        var mi = new MediaInfo.MediaInfo();
        mi.Open(tempFilePath);

        double durationInSeconds = double.Parse(mi.Get(StreamKind.Video, 0, "Duration")) / 1000;
        int durationInMinutes = (int)Math.Round(durationInSeconds / 60);

        File.Delete(tempFilePath); // Удаляем временный файл

        return durationInMinutes;
    }
}