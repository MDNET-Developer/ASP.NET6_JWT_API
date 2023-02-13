using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MD.JWTApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly MuradJwtContext _muradJwtContext;

        public Repository(MuradJwtContext muradJwtContext)
        {
            _muradJwtContext = muradJwtContext;
        }

        public async Task CreateAsync(T entity)
        {
           await _muradJwtContext.Set<T>().AddAsync(entity);
            await _muradJwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _muradJwtContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _muradJwtContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _muradJwtContext.Set<T>().FindAsync(id);
        }

        public  async Task RemoveAsync(T entity)
        {
              _muradJwtContext.Set<T>().Remove(entity);
            await _muradJwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _muradJwtContext.Set<T>().Update(entity);
            await _muradJwtContext.SaveChangesAsync();
        }
    }
}
