using Data.Context;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RepositoryBase
    {
        protected readonly IContext DbContext;

        public RepositoryBase(IEnumerable<IContext> contents, DataSourceOptions datasource)
        {
            DbContext = contents.FirstOrDefault(p => p.DataSourceOptions == datasource);

        }
    }
}
