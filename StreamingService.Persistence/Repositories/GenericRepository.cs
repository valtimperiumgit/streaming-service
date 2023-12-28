using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StreamingService.Persistence.DbContexts;

namespace StreamingService.Persistence.Repositories;

public abstract class GenericRepository<TEntity> 
    where TEntity : class
{
    protected AppDbContext DbContext { get; }

    protected GenericRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public Task<TEntity?> GetByProperty(string propertyName, object value, CancellationToken cancellationToken)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "entity");
        var property = typeof(TEntity).GetProperty(propertyName);

        if (property is null)
        {
            throw new ArgumentException($"Property {propertyName} does not exist on type {typeof(TEntity).Name}.");
        }

        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var equalTo = Expression.Equal(propertyAccess, Expression.Constant(value));
        var lambda = Expression.Lambda<Func<TEntity, bool>>(equalTo, parameter);

        return DbContext.Set<TEntity>().FirstOrDefaultAsync(lambda, cancellationToken: cancellationToken);
    }

    public async Task<List<TEntity>> Get(CancellationToken cancellationToken)
    {
        return await DbContext.Set<TEntity>().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task Insert(TEntity entity, CancellationToken cancellationToken)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    
    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
        DbContext.SaveChanges();
    }
}