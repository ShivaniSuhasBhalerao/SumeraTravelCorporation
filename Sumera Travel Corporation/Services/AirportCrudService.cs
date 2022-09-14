using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Services
{
    public class AirportCrudService : IAirportCrudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AirportCrudService(ApplicationDbContext _newvariable, IMapper _newmapper)
        {
            _context = _newvariable;
            _mapper = _newmapper;
        }
        public async Task DeleteAirportAsync(int id)
        {
            var delairport = await _context.Airports.SingleAsync(c => c.AirportId == id);
            _context.Airports.Remove(delairport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AirportDto>> GetAirportsAsync()
        {

            try
            {
                var airports = await _context.Airports.ToListAsync();
                var aiportdto = airports.Select(d => _mapper.Map<AirportDto>(d)).ToList();
                return aiportdto;
            }

            catch (Exception ex)
            {
                return null;
            }
        }





        public async Task<AirportDto> GetAirportAsync(int id)
        {
            var getairportbyid = await _context.Airports.FindAsync(id);
            var getairportbyiddto = _mapper.Map<AirportDto>(getairportbyid);
            return getairportbyiddto;
        }




        public async Task PutAirportAsync(AirportDto airport)
        {
            var putairport = _mapper.Map<Airport>(airport);
            _context.Airports.Update(putairport);
            await _context.SaveChangesAsync();



        }



        public async Task PostAirportAsync(AirportDto airport)
        {
            var postairport = _mapper.Map<Airport>(airport);
            _context.Add(postairport);
            await _context.SaveChangesAsync();

        }
    }
}
