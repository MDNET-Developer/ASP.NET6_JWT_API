using System.Linq.Expressions;

namespace MD.JWTApp.Back.Core.Application.Interfaces
{
    public interface IRepository<T>where T :class,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
