using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;
using Sumera_Travel_Corporation.Repository_Pattern;

namespace Sumera_Travel_Corporation.Services
{
    public class LocationCrudService:ILocationCrudService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper _mapper;

        public LocationCrudService(ILocationRepository newvariable, IMapper newmapper)
        {
            this.locationRepository = newvariable;
            this._mapper=newmapper;
        }
        public async Task<List<LocationDto>> GetLocationsAsync()
        {
            var customers = await locationRepository.GetLocationsAsync();
            return customers;

        }
       

        public async Task<LocationDto> GetLocationAsync(int id)
        {

            var location = await locationRepository.GetLocationAsync(id);

            return location;
        }
        public async Task PostLocationAsync(LocationDto location)
        {
            await locationRepository.PostLocationAsync(location);
           
        }  

      

        public async Task PutLocationAsync(LocationDto locationDto)
        {
              await locationRepository.PutLocationAsync(locationDto);
               
         
        }
        
        public async Task DeleteLocationAsync(int id)
        {
            //await locationRepository.DeleteLocationAsync(id);
            await locationRepository.DeleteLocationAsync(id);
           


        }







    }
}
