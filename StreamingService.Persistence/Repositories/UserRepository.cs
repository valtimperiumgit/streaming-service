using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Repositories;
using StreamingService.Domain.User;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}