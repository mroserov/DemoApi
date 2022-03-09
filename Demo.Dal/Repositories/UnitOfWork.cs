using Demo.Contracts.Dal;

namespace Demo.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;

        private IStepRepository StepRepository;
        private IDemoTaskRepository DemoTaskRepository;

        public IStepRepository Steps => this.StepRepository ??= new StepRepository(this.context);
        public IDemoTaskRepository DemoTasks => this.DemoTaskRepository ??= new DemoTaskRepository(this.context);

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await this.context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
