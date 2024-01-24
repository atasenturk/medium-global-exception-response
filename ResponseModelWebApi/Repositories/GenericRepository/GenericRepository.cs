using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ResponseModelWebApi.Repositories.GenericRepository
{
    public class GenericRepository<T>(ResponseModelWebApiContext context) : IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity!);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
