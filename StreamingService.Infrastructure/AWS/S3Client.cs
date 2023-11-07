using Amazon.S3;
using Amazon.S3.Model;
using StreamingService.Application.Abstractions.Storeges;

namespace StreamingService.Infrastructure.AWS;

public class S3Client : IBucket
{ 
    private readonly IAmazonS3 _client;
    
    private const string BucketName = "diplom-streaming";
    private const string S3BaseUrl = "https://s3.amazonaws.com/";

    public S3Client(IAmazonS3 client)
    {
        _client = client;
    }
    
    public async Task<string> UploadFileAsync(Stream stream, string key)
    {
        var request = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = key,
            InputStream = stream
        };
        
        await _client.PutObjectAsync(request);
        
        return GetFileUrl(key);
    }

    public async Task<Stream> GetFileAsync(string key)
    {
        var request = new GetObjectRequest
        {
            BucketName = BucketName,
            Key = key
        };

        var response = await _client.GetObjectAsync(request);
        return response.ResponseStream;
    }

    public async Task CreateFolder(string folderName)
    {
        var request = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = folderName + "/"
        };
        
        await _client.PutObjectAsync(request);
    }
    
    private string GetFileUrl(string key)
    {
        return $"{S3BaseUrl}{BucketName}/{key}";
    }
}