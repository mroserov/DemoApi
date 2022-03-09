using Demo.Contracts.Entities;

namespace Demo.Contracts.Bl
{
    public interface IDemoTaskBl
    {
        Task<int> CreateAsync(DemoTask demoTask);
        Task<IEnumerable<DemoTask>> GetAllAsync();
        Task<DemoTask> GetByIdAsync(int id);
        Task<DemoTask> DeleteAsync(int id);
        Task<bool> UpdateAsync(DemoTask demoTask);
    }
}
