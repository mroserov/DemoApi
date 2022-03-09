using Demo.Contracts.Dal;
using Demo.Contracts.Entities;

namespace Demo.Dal.Repositories
{
    internal class DemoTaskRepository : Repository<DemoTask, int>, IDemoTaskRepository
    {
        private readonly DataContext context;
        public DemoTaskRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
