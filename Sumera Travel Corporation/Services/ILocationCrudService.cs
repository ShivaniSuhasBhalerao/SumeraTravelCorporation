﻿using Sumera_Travel_Corporation.Data.Dtos;

namespace Sumera_Travel_Corporation.Services
{
    public interface ILocationCrudService
    {
        public Task<List<LocationDto>> GetLocationsAsync();

        public Task<LocationDto> GetLocationAsync(int id);
        public Task PutLocationAsync(LocationDto locationDto);
        public Task PostLocationAsync(LocationDto locationDto);

        public Task DeleteLocationAsync(int id);


    }
}
