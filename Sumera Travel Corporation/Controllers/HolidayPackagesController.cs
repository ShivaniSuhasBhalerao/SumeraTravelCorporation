using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;
using Sumera_Travel_Corporation.Services;

namespace Sumera_Travel_Corporation.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HolidayPackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHolidayPackageCrudService _holidayCrudService;

        public HolidayPackagesController(ApplicationDbContext context, IHolidayPackageCrudService holidayCrudService)
        {
            _context = context;
            _holidayCrudService = holidayCrudService;
        }

        // GET: api/HolidayPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayPackagesDto>>> GetHolidayPackages()
        {
            var holidaypackage = await _holidayCrudService.GetHolidayPackagesAsync();
            return holidaypackage;

        }
       


        // GET: api/HolidayPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayPackagesDto>> GetHolidayPackage(int id)
        {
            var holidaypackage = await _holidayCrudService.GetHolidayPackageAsync(id);

            return holidaypackage;
        }

        // POST: api/HolidayPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HolidayPackage>> PostHolidayPackage(HolidayPackagesDto holidayPackagedto)
        {
            await _holidayCrudService.PostHolidayPackageAsync(holidayPackagedto);
            return CreatedAtAction("GetHolidayPackages", new { id = holidayPackagedto.HolidayPackageId}, holidayPackagedto);
        }
        


        // PUT: api/HolidayPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayPackage( HolidayPackagesDto holidayPackagedto)
        {

            try
            {
                await _holidayCrudService.PutHolidayPackageAsync(holidayPackagedto);
                return Ok(holidayPackagedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        



        // DELETE: api/HolidayPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayPackage(int id)
        {
            await _holidayCrudService.DeleteHolidayPackageAsync(id);
            return Ok();
        }
        [HttpGet("{locationFrom}/{locationTo}")]
        public async Task<List<HolidayPackagesDto>> GetHolidayPackagesAsync(string locationFrom, string locationTo)
        {
            var holidaypackage = await _holidayCrudService.GetHolidayPackagesAsync(locationFrom, locationTo);

            return holidaypackage;
        }



    }
}
