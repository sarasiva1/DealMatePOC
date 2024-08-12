using System.Linq.Expressions;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    Task<T> Update(T entity);

    Task<T> Remove(T entity);
    Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}
