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
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHotelCrudService _HotelCrudService;

        public HotelsController(ApplicationDbContext context, IHotelCrudService hotelCrudService)
        {
            _context = context;
             _HotelCrudService = hotelCrudService;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotelsAsync()
        {
            var hotels= await _HotelCrudService.GetHotelsAsync();
            return hotels;


        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotelAsync(int id)
        {
          var hotel = await _HotelCrudService.GetHotelAsync(id);
            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAsync( HotelDto hotel)
        {

            try
            {
                await _HotelCrudService.PutHotelAsync(hotel);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotelAsync(HotelDto hotel)
        {
            await _HotelCrudService.PostHotelAsync(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }
       
        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAsync(int id)
        {
            //if (_context.Hotels == null)
            //{
            //    return NotFound();
            //}
            //var hotel = await _context.Hotels.FindAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //_context.Hotels.Remove(hotel);
            //await _context.SaveChangesAsync();
            await _HotelCrudService.DeleteHotelAsync(id);
            return Ok();

            
        }

       
    }
}
