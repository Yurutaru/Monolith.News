using Microsoft.EntityFrameworkCore;
using Monolith.News.Domain;
using Monolith.News.Domain.Entities.Interfaces;
using Monolith.News.Infrastructure.Persistence.Extensions.Specification;

namespace Monolith.News.Persistence.Repositories;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext dbContext;

    private DbSet<T> EntitiesSet => dbContext.Set<T>();

    public EntityFrameworkRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await EntitiesSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        await EntitiesSet.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        EntitiesSet.UpdateRange(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    //public Task<int> Count(ISpecification<T> specification)
    //{
    //    if (specification == null)
    //    {
    //        throw new ArgumentNullException(nameof(specification));
    //    }

    //    var entities = specification.AddPredicates(EntitiesSet);
    //    return entities.CountAsync();
    //}

    //public Task<bool> Exists(ISpecification<T> specification)
    //{
    //    if (specification == null)
    //    {
    //        throw new ArgumentNullException(nameof(specification));
    //    }

    //    var entities = specification.AddPredicates(EntitiesSet);
    //    return entities.AnyAsync();
    //}

    public async ValueTask<T?> GetById(object id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var result = await EntitiesSet.FindAsync(id);
        return result;
    }

    public async Task<T?> Get(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var result = EntitiesSet.Specify(specification);
        return await result.FirstOrDefaultAsync();
    }

    public async Task<T[]> List(ISpecification<T> specification, int skip = 0, int take = 100)
    {
        var entities = EntitiesSet
            .Specify(specification)
            .Skip(skip)
            .Take(take);

        var result = await entities.ToArrayAsync();
        return result;
    }
}