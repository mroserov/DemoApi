using Demo.Contracts.Dal;
using Demo.Contracts.Entities;

namespace Demo.Dal.Repositories
{
    internal class StepRepository : Repository<Step, int>, IStepRepository
    {
        private readonly DataContext context;
        public StepRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
