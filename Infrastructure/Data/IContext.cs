using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IContext : IDisposable
    {
        DataSourceOptions DataSourceOptions { get; }
        bool IsTransactionStarted { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();

        Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text);

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", CommandType commandType = CommandType.Text);

        Task<int> SaveAsync<T>(T entity) where T : EntityBase;
    }
}
