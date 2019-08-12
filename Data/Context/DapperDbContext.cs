﻿using Dapper;
using Dapper.Contrib.Extensions;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using TCBase.Data.Connection;

namespace Data.Context
{
    public abstract class DapperDbContext : IContext
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private int? _commandTimeout = null;
        private readonly DapperDbContextOptions _options;

        public bool IsTransactionStarted { get; set; }

        /// <summary>
        /// 多数据库上下文支持
        /// </summary>
        public abstract DataSourceOptions DataSourceOptions { get; }

        //protected abstract IDbConnection CreateConnection(string connectionString);
        protected abstract IDbConnection CreateConnection(string connectionString);

        protected DapperDbContext(IOptionsFactory<DapperDbContextOptions> optionsAccessors)
        //protected DapperDbContext(IEnumerable<IOptions<DapperDbContextOptions>> optionsAccessors)
        {
            //SqlMapperExtensions.GetDatabaseType = DataSource.GetDatabaseType;
            SqlMapperExtensions.GetDatabaseType = conn => "MySqlConnection";
            SqlMapperExtensions.TableNameMapper = (name) => name.Name;
            _options = optionsAccessors.Create(DataSourceOptions.ToString());
            //_options = optionsAccessors.FirstOrDefault(p=>p.Configure).Value;
            _connection = CreateConnection(_options.Configuration);

            _connection.Open();
        }

        public void BeginTransaction()
        {
            if (IsTransactionStarted)
            {
                throw new InvalidOperationException("Transaction is already started.");
            }

            _transaction = _connection.BeginTransaction();
            IsTransactionStarted = true;
        }

        public void Commit()
        {
            if (!IsTransactionStarted)
            {
                throw new InvalidOperationException("No transaction started.");
            }

            _transaction.Commit();
            _transaction = null;

            IsTransactionStarted = false;
        }

        public void Rollback()
        {
            if (!IsTransactionStarted)
            {
                throw new InvalidOperationException("No transaction started.");
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            IsTransactionStarted = false;
        }

        #region Dapper Execute & Query

        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return await _connection.ExecuteAsync(sql, param, _transaction, _commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return await _connection.QueryAsync<T>(sql, param, _transaction, _commandTimeout, commandType);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction, _commandTimeout, commandType);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", CommandType commandType = CommandType.Text)
        {
            return await _connection.QueryAsync(sql, map, param, _transaction, true, splitOn, _commandTimeout, commandType);
        }

        public async Task<int> SaveAsync<T>(T entity) where T : EntityBase
        {
            //注意:主键为非自增类型时，Dapper.Contrib的Insert永远返回0。
            var result = await _connection.InsertAsync<T>(entity, _transaction, _commandTimeout);
            return result;
        }



        #endregion Dapper Execute & Query

        public void Dispose()
        {
            if (IsTransactionStarted)
                Rollback();

            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}
