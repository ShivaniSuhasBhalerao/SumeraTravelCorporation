using Sumera_Travel_Corporation.Data.Dtos;

namespace Sumera_Travel_Corporation.Services
{
    public interface IHolidayBookingCrudService
    {
        public Task<List<HolidayBookingDto>> GetHolidayBookingsAsync();

        public Task<HolidayBookingDto> GetHolidayBookingAsync(int id);
        public Task PutHolidayBookingAsync(HolidayBookingDto holidayBookingDto);
        public Task PostHolidayBookingAsync(HolidayBookingDto holidayBookingDto);

        public Task DeleteHolidayBookingAsync(int id);
    }
}
