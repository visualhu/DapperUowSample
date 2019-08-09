using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Model.PublicService
{
    public interface IFlightUserRepository
    {
        Task<bool> AddAsync(FlightUser flightUser);
        Task<IEnumerable<FlightUser>> GetAllAsync();
        Task<FlightUser> GetByIdAsync(long id);
        //Task<bool> DeleteAsync(long id);
        //Task<bool> UpdateAsync(FlightUser flightUser);
    }
}
