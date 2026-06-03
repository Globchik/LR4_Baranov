using System.Linq.Expressions;
using LR4_Baranov.Models;
using Microsoft.EntityFrameworkCore;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly UniversityDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseService(UniversityDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();

            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();

            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}