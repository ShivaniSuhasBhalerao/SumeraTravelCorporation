using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Services
{
    public interface IAirportCrudService
    {
        public Task<List<AirportDto>> GetAirportsAsync();

        public Task<AirportDto> GetAirportAsync(int id);
      
        public Task PutAirportAsync( AirportDto airport);

        public Task DeleteAirportAsync(int id);

        public Task PostAirportAsync(AirportDto airport);
        
    }
}
