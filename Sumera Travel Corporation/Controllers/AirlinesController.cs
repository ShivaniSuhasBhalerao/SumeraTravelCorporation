using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AirlinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Airlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airline>>> GetAirlines()
        {
          if (_context.Airlines == null)
          {
              return NotFound();
          }
            return await _context.Airlines.ToListAsync();
        }

        // GET: api/Airlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airline>> GetAirline(int id)
        {
          if (_context.Airlines == null)
          {
              return NotFound();
          }
            var airline = await _context.Airlines.FindAsync(id);

            if (airline == null)
            {
                return NotFound();
            }

            return airline;
        }

        // PUT: api/Airlines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirline(int id, Airline airline)
        {
            if (id != airline.AirlineId)
            {
                return BadRequest();
            }

            _context.Entry(airline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Airlines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airline>> PostAirline(Airline airline)
        {
          if (_context.Airlines == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Airlines'  is null.");
          }
            _context.Airlines.Add(airline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirline", new { id = airline.AirlineId }, airline);
        }

        // DELETE: api/Airlines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            if (_context.Airlines == null)
            {
                return NotFound();
            }
            var airline = await _context.Airlines.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }

            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirlineExists(int id)
        {
            return (_context.Airlines?.Any(e => e.AirlineId == id)).GetValueOrDefault();
        }
    }
}
