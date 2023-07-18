using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> AddRangeAsycn(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
