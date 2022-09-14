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
    public class HolidayBookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHolidayBookingCrudService _holidayCrudService;
        public HolidayBookingsController(ApplicationDbContext context,IHolidayBookingCrudService holidayBookingCrudService)
        {
            _context = context;
            _holidayCrudService = holidayBookingCrudService;
        }

        // GET: api/HolidayBookings
        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayBookingDto>>> GetHolidayBookings()
        {
            var holiday = await _holidayCrudService.GetHolidayBookingsAsync();
            return holiday;

        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayBookingDto>> GetHolidayBooking(int id)
        {
            var holiday = await _holidayCrudService.GetHolidayBookingAsync(id);

            return holiday;
        }


        // POST: api/HolidayPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HolidayBooking>> PostHolidayBooking(HolidayBookingDto holidayBookingDto)
        {
            await _holidayCrudService.PostHolidayBookingAsync(holidayBookingDto);
            return CreatedAtAction("GetHolidayBookings", new { id = holidayBookingDto.HolidayBookingId }, holidayBookingDto);
        }



        // PUT: api/HolidayPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayBooking(HolidayBookingDto holidayBookingDto)
        {

            try
            {
                await _holidayCrudService.PutHolidayBookingAsync(holidayBookingDto);
                return Ok(holidayBookingDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // DELETE: api/HolidayPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayBooking(int id)
        {
            await _holidayCrudService.DeleteHolidayBookingAsync(id);
            return Ok();
        }


    }
}
