using Data.Context;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;
//using TCBase.Data.Connection;

namespace Data
{
    public class PublicServiceDbContext : DapperDbContext
    {
        public override DataSourceOptions DataSourceOptions => DataSourceOptions.TCFlyPublicService;
        public PublicServiceDbContext(IOptions<DapperDbContextOptions> optionsAccessor) : base(optionsAccessor) { }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            IDbConnection conn = new MySqlConnection(connectionString);
            return conn;
            //return DataSource.GetConnection(dbName);
        }
    }
}
