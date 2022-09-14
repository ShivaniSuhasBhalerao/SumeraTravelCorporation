using Sumera_Travel_Corporation.Data.Dtos;

namespace Sumera_Travel_Corporation.Services
{
    public interface IHolidayPackageCrudService
    {
        public Task<List<HolidayPackagesDto>> GetHolidayPackagesAsync();

        public Task<HolidayPackagesDto> GetHolidayPackageAsync(int id);
        public Task PutHolidayPackageAsync(HolidayPackagesDto holidayPackagesDto);
        public Task PostHolidayPackageAsync(HolidayPackagesDto holidayPackagesDto);

        public Task DeleteHolidayPackageAsync(int id);

        public Task<List<HolidayPackagesDto>> GetHolidayPackagesAsync(string locationFrom, string locationTo);
    }
}
