using Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
where TContext : DbContext, new()
{


    public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges)
    {
        using (var context = new TContext())
        {
            
            return trackChanges
                ? context.Set<TEntity>().SingleOrDefault(filter)
                : context.Set<TEntity>().AsNoTracking().SingleOrDefault(filter);
        }

    }



    public IQueryable<TEntity> FindAllWithAsNoTracking(bool trackChanges)
    {
        using (var context = new TContext())
        {
            
            return trackChanges
                ? context.Set<TEntity>()
                : context.Set<TEntity>().AsNoTracking();
        }
    }

    public TEntity? FindByConditionAndAsNoTracking(Expression<Func<TEntity, bool>> expression, bool trackChanges)
    {
        using (var context = new TContext())
        {

            return trackChanges
                ? context.Set<TEntity>().Where(expression).SingleOrDefault()
                : context.Set<TEntity>().Where(expression).AsNoTracking().SingleOrDefault();
        }

    }

    public void Add(TEntity entity)
    {
        using (var context = new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChangesAsync();
        }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter is null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();

        }
    }

    public void Delete(TEntity entity)
    {
        using (var context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChangesAsync();
        }
    }

    public void Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChangesAsync();
        }
    }
}