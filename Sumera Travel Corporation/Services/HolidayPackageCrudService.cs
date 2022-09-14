using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;

namespace Sumera_Travel_Corporation.Services
{
    public class HolidayPackageCrudService : IHolidayPackageCrudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HolidayPackageCrudService(ApplicationDbContext newvariable, IMapper newmapper)
        {
            this._context = newvariable;
            this._mapper = newmapper;
        }

        public async Task<List<HolidayPackagesDto>> GetHolidayPackagesAsync()
        {
            try
            {
                var a = await _context.HolidayPackages.Include(x => x.fromlocation)
                  .Include(z => z.tolocation)
                  .Include(y => y.hotel)
                  .ToListAsync();
                var holidaydto = a
                    .Select(d => _mapper.Map<HolidayPackagesDto>(d))
                    .ToList();
                return holidaydto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HolidayPackagesDto> GetHolidayPackageAsync(int id)
        {
            var getholidaypackagebyid = await _context.HolidayPackages.FindAsync(id);
            var getholidaypackagebyiddto = _mapper.Map<HolidayPackagesDto>(getholidaypackagebyid);
            return getholidaypackagebyiddto;
        }

        public async Task PostHolidayPackageAsync(HolidayPackagesDto holidayPackagesDto)
        {
            var postholidaypackage = _mapper.Map<HolidayPackage>(holidayPackagesDto);
            _context.Add(postholidaypackage);
            await _context.SaveChangesAsync();
        }



        public async Task PutHolidayPackageAsync(HolidayPackagesDto holidayPackagesDto)
        {
            var putholiday = _mapper.Map<HolidayPackage>(holidayPackagesDto);
            _context.HolidayPackages.Update(putholiday);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteHolidayPackageAsync(int id)
        {
            var delholiday = await _context.HolidayPackages.SingleAsync(c => c.HolidayPackageId == id);
            _context.HolidayPackages.Remove(delholiday);
            await _context.SaveChangesAsync();
        }




        [HttpGet("{locationFrom}/{locationTo}")]
        public async Task<List<HolidayPackagesDto>> GetHolidayPackagesAsync(string locationFrom, string locationTo)
        {


            if (!(await _context.Locations.AnyAsync(f => f.LocationName == locationFrom) &&
               await _context.Locations.AnyAsync(f => f.LocationName == locationTo)))
                return null;

            var locationFromRefId = await _context.Locations
                .Where(l => l.LocationName == locationFrom)
                .Select(l => l.LocationId)
                .FirstOrDefaultAsync();

            var locationToRefId = await _context.Locations
                .Where(l => l.LocationName == locationTo)
                .Select(l => l.LocationId)
                .FirstOrDefaultAsync();



            var locationsQuery = _context.HolidayPackages.Include(X => X.fromlocation).Include(Y => Y.tolocation)
                .Where(f =>
                    f.fromlocation.LocationId == locationFromRefId &&
                    f.tolocation.LocationId == locationToRefId
                    );

          var a = locationsQuery
              .Select(d => _mapper.Map<HolidayPackagesDto>(d))
                .ToList();
            //var a = _mapper.Map<HolidayPackagesDto>(locationsQuery);

            return a;
           
        }
         

        
    }
}
