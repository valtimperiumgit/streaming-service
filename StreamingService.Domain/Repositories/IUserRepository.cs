namespace StreamingService.Domain.Repositories;
using User;

public interface IUserRepository
{
    public Task<User?> GetByProperty(string propertyName, object value, CancellationToken cancellationToken);

    public Task Insert(User user, CancellationToken cancellationToken);
}