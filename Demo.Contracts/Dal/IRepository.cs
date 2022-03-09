namespace Demo.Contracts.Dal
{
    public interface IRepository<TEntity, in TId>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
    }
}
