using System;

namespace Infrastructure.Data
{
    public interface IContext : IDisposable
    {
        DataSourceOptions DataSourceOptions { get; }
        bool IsTransactionStarted { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
