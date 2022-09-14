using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;

namespace Sumera_Travel_Corporation.Repository_Pattern
{
    public class LocationRepository:ILocationRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(ApplicationDbContext newvariable, IMapper newmapper)
        {
            this._context = newvariable;
            this._mapper = newmapper;
        }
        public async Task<List<LocationDto>> GetLocationsAsync()
        {
            try
            {
                var getlocation = await _context.Locations.ToListAsync();
                var getlocationdto = getlocation.Select(d => _mapper.Map<LocationDto>(d)).ToList();
                return getlocationdto;

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public async Task<LocationDto> GetLocationAsync(int id)
        {
            var getlocationbyid = await _context.Locations.FindAsync(id);
            var getlocationbyiddto = _mapper.Map<LocationDto>(getlocationbyid);
            return getlocationbyiddto;
        }
        public async Task PostLocationAsync(LocationDto location)
        {
            var postlocation = _mapper.Map<Locations>(location);
            _context.Add(postlocation);
            await _context.SaveChangesAsync();
        }


        public async Task PutLocationAsync(LocationDto locationDto)
        {
            var putlocation = _mapper.Map<Locations>(locationDto);
            _context.Locations.Update(putlocation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var dellocation = await _context.Locations.SingleAsync(c => c.LocationId == id);
            _context.Locations.Remove(dellocation);
            await _context.SaveChangesAsync();
        }

        
        }
    }

