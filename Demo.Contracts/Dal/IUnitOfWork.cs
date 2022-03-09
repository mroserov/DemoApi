namespace Demo.Contracts.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IStepRepository Steps { get; }
        IDemoTaskRepository DemoTasks { get; }

        Task<int> CommitAsync();
    }
}
