using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Data.Context
{
    public class DapperUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IEnumerable<DapperDbContext> _contexts;

        public DapperUnitOfWorkFactory(IEnumerable<DapperDbContext> contexts)
        {
            _contexts = contexts;
        }

        public IUnitOfWork Create(DataSourceOptions datasource)
        {
            var context = _contexts.FirstOrDefault(p => p.DataSourceOptions == datasource);
            return new UnitOfWork(context);
        }
    }
}
