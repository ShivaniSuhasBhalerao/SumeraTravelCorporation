using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;
using Sumera_Travel_Corporation.Services;

namespace Sumera_Travel_Corporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAirportCrudService _iairportCrudService;

        public AirportsController(ApplicationDbContext context,IAirportCrudService airportCrudService)

        {
            _context = context;
            _iairportCrudService = airportCrudService;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirportsAsync()
        {
          var getairport=await _iairportCrudService.GetAirportsAsync();
            return getairport;
        }
        
    

        // GET: api/Airports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDto>> GetAirportAsync(int id)
        {
            var airport = await _iairportCrudService.GetAirportAsync(id);
           return airport;

           

        }

        // PUT: api/Airports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport( AirportDto airport)
        {
            try
            {
                await _iairportCrudService.PutAirportAsync(airport);
                return Ok(airport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        // POST: api/Airports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airport>> PostAirportAsync(AirportDto airport)
        {
            await _iairportCrudService.PostAirportAsync(airport);
            return CreatedAtAction("GetAirport", new { id = airport.AirportId }, airport);

        }
            // DELETE: api/Airports/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            await _iairportCrudService.DeleteAirportAsync(id);
            return Ok();
        }

       
    }
}
