using Sumera_Travel_Corporation.Data.Dtos;

namespace Sumera_Travel_Corporation.Services
{
    public interface IHotelCrudService
    {
        public Task<List<HotelDto>> GetHotelsAsync();

        public Task<HotelDto> GetHotelAsync(int id);

        public Task PutHotelAsync(HotelDto hotel);

        public Task PostHotelAsync(HotelDto hotel);

        public Task DeleteHotelAsync(int id);

    }
}
