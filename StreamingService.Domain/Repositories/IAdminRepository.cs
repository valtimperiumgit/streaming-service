namespace StreamingService.Domain.Repositories;

public interface IAdminRepository
{
    public Task<Admin.Admin?> GetByProperty(string propertyName, object value, CancellationToken cancellationToken);
}