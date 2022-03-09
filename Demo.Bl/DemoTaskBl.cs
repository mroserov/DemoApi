using Demo.Contracts.Bl;
using Demo.Contracts.Dal;
using Demo.Contracts.Entities;

namespace Demo.Bl
{
    public class DemoTaskBl : IDemoTaskBl
    {
        private readonly IUnitOfWork unitOfWork;

        public DemoTaskBl(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateAsync(DemoTask demoTask)
        {
            await this.unitOfWork.DemoTasks.CreateAsync(demoTask).ConfigureAwait(false);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
            return demoTask.Id;
        }

        public async Task<DemoTask> DeleteAsync(int id)
        {
            var demoTask = await this.unitOfWork.DemoTasks.DeleteAsync(id).ConfigureAwait(false);

            if (demoTask == null)
            {
                return null;
            }

            await this.unitOfWork.CommitAsync().ConfigureAwait(false);

            return demoTask;
        }

        public async Task<IEnumerable<DemoTask>> GetAllAsync()
        {
            return await this.unitOfWork.DemoTasks.GetAllAsync();
        }

        public async Task<DemoTask> GetByIdAsync(int id)
        {
            return await this.unitOfWork.DemoTasks.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(DemoTask demoTask)
        {
            try
            {
                await this.unitOfWork.DemoTasks.UpdateAsync(demoTask).ConfigureAwait(false);
                await this.unitOfWork.CommitAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}