using Data.Context;
using Data.Model.Sentry;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class SysMenuRepository : RepositoryBase, ISysMenuRepository
    {

        public SysMenuRepository(IEnumerable<DapperDbContext> contexts) : base(contexts, DataSourceOptions.TCFlySentryPlus)
        {

        }

        public async Task<bool> AddAsync(SysMenu sysMenu)
        {
            await DbContext.SaveAsync<SysMenu>(sysMenu);
            return true;
        }
        public async Task<IEnumerable<SysMenu>> GetAllAsync()
        {
            return await DbContext.QueryAsync<SysMenu>(@"SELECT * from  customer");
        }
        public async Task<SysMenu> GetByIdAsync(string id)
        {
            string sql = @"SELECT*
                            FROM customer
                            WHERE Id = @Id";
            return await DbContext.QueryFirstOrDefaultAsync<SysMenu>(sql, new { Id = id });
        }
    }
}
