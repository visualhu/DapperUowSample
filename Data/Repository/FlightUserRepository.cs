using Data.Context;
using Data.Model.PublicService;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class FlightUserRepository : RepositoryBase, IFlightUserRepository
    {


        public FlightUserRepository(IEnumerable<IContext> contexts) : base(contexts, DataSourceOptions.TCFlyPublicService)
        {

        }

        public async Task<bool> AddAsync(FlightUser flightUser)
        {
            await DbContext.SaveAsync<FlightUser>(flightUser);
            return true;
        }
        public async Task<IEnumerable<FlightUser>> GetAllAsync()
        {
            return await DbContext.QueryAsync<FlightUser>(@"SELECT * from  order");
        }
        public async Task<FlightUser> GetByIdAsync(long id)
        {
            string sql = @"SELECT *
                            FROM `Order`
                            WHERE Id = @Id";
            return await DbContext.QueryFirstOrDefaultAsync<FlightUser>(sql, new { Id = id });
        }
        //Task<bool> DeleteAsync(long id);
        //Task<bool> UpdateAsync(FlightUser flightUser);
    }
}
