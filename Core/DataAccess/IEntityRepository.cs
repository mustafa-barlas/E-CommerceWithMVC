using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    IQueryable<T> FindAllWithAsNoTracking(bool trackChanges);

    T? FindByConditionAndAsNoTracking(Expression<Func<T, bool>> expression, bool trackChanges);


    List<T> GetAll(Expression<Func<T, bool>> filter = null);

    T? Get(Expression<Func<T, bool>> filter, bool trackChanges);

    void Add(T entity);

    void Delete(T entity);

    void Update(T entity);


}
