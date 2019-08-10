using Data.Context;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
//using TCBase.Data.Connection;

namespace Data
{
    public class SentryDbContext : DapperDbContext
    {
        public override DataSourceOptions DataSourceOptions => DataSourceOptions.TCFlySentryPlus;
        public SentryDbContext(IEnumerable<IOptions<DapperDbContextOptions>> optionsAccessors) : base(optionsAccessors) { }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            IDbConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        //protected override IDbConnection CreateConnection(string connection)
        //{
        //    //IDbConnection conn = new MySqlConnection(connectionString);
        //    return DataSource.GetConnection(dbName);
        //}
    }
}
