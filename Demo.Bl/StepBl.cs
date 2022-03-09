using Demo.Contracts.Bl;
using Demo.Contracts.Dal;
using Demo.Contracts.Entities;

namespace Demo.Bl
{
    public class StepBl : IStepBl
    {
        private readonly IUnitOfWork unitOfWork;

        public StepBl(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateAsync(Step step)
        {
            await this.unitOfWork.Steps.CreateAsync(step).ConfigureAwait(false);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
            return step.Id;
        }

        public async Task<Step> DeleteAsync(int id)
        {
            var step = await this.unitOfWork.Steps.DeleteAsync(id).ConfigureAwait(false);

            if (step == null)
            {
                return null;
            }

            await this.unitOfWork.CommitAsync().ConfigureAwait(false);

            return step;
        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            return await this.unitOfWork.Steps.GetAllAsync();
        }

        public async Task<Step> GetByIdAsync(int id)
        {
            return await this.unitOfWork.Steps.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Step step)
        {
            await this.unitOfWork.Steps.UpdateAsync(step).ConfigureAwait(false);
            await this.unitOfWork.CommitAsync().ConfigureAwait(false);
            return true;
        }
    }
}