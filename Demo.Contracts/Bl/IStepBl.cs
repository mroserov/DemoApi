using Demo.Contracts.Entities;

namespace Demo.Contracts.Bl
{
    public interface IStepBl
    {
        Task<int> CreateAsync(Step step);
        Task<IEnumerable<Step>> GetAllAsync();
        Task<Step> GetByIdAsync(int id);
        Task<Step> DeleteAsync(int id);
        Task<bool> UpdateAsync(Step step);
    }
}
