using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Model.Sentry
{
    public interface ISysMenuRepository
    {
        Task<bool> AddAsync(SysMenu sysMenu);
        Task<IEnumerable<SysMenu>> GetAllAsync();
        Task<SysMenu> GetByIdAsync(string id);
        //Task<bool> DeleteAsync(long id);
        //Task<bool> UpdateAsync(SysMenu sysMenu);
    }
}
