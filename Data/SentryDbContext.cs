﻿using Data.Context;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using System.Data;
using TCBase.Data.Connection;

namespace Data
{
    public class SentryDbContext : DapperDbContext
    {
        public override DataSourceOptions DataSourceOptions => DataSourceOptions.TCFlySentryPlus;
        public SentryDbContext(IOptions<DapperDbContextOptions> optionsAccessor) : base(optionsAccessor) { }

        protected override IDbConnection CreateConnection(string dbName)
        {
            //IDbConnection conn = new MySqlConnection(connectionString);
            return DataSource.GetConnection(dbName);
        }
    }
}