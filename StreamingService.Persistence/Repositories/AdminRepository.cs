using StreamingService.Domain.Admin;
using StreamingService.Domain.Repositories;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}