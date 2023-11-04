using System.Security.Cryptography;
using System.Text;
using StreamingService.Application.Core.Cryptography;

namespace StreamingService.Infrastructure.Cryptography;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        MD5 md5 = MD5.Create();

        byte[] bytes = Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(bytes);

        StringBuilder builder = new StringBuilder();
        foreach (var hashByte in hash)
        {
            builder.Append(hashByte.ToString("X2"));
        }
        
        return builder.ToString();
    }
}