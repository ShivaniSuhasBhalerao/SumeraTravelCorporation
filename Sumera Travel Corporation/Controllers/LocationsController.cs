using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;
using Sumera_Travel_Corporation.Services;

namespace Sumera_Travel_Corporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocationCrudService _locationCrudService;

        public LocationsController(ApplicationDbContext context, ILocationCrudService locationCrudService)
        {
            _context = context;
            _locationCrudService = locationCrudService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations()
        {
            var customers = await _locationCrudService.GetLocationsAsync();
            return customers;

        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetLocation(int id)
        {
           var location = await _locationCrudService.GetLocationAsync(id);

            return location;
        }

        

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locations>> PostLocation(LocationDto location)
        {
            await _locationCrudService.PostLocationAsync(location);
            return CreatedAtAction("GetLocation", new { id= location.LocationId },location);
        }
        

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(LocationDto locationdto)
        {
            try
            {
                await _locationCrudService.PutLocationAsync(locationdto);
                return Ok(locationdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationCrudService.DeleteLocationAsync(id);
            return Ok();
        }

       
    }
}
