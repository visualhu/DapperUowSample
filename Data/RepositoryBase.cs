using Data.Context;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RepositoryBase
    {
        protected readonly DapperDbContext DbContext;

        public RepositoryBase(IEnumerable<DapperDbContext> contents, DataSourceOptions datasource)
        {
            DbContext = contents.FirstOrDefault(p => p.DataSourceOptions == datasource);

        }
    }
}
