namespace StreamingService.Application.Abstractions.Storeges;

public interface IBucket
{
    public Task<string> UploadFileAsync(Stream stream, string key);

    public Task<Stream> GetFileAsync(string key);

    public Task CreateFolder(string folderName);
}