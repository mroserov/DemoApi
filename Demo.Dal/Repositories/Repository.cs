using Demo.Contracts.Dal;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.Repositories
{
    internal class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await this.context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<TEntity> DeleteAsync(TId id)
        {
            var entity = await this.context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                return null;
            }

            this.context.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await this.context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public Task UpdateAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
