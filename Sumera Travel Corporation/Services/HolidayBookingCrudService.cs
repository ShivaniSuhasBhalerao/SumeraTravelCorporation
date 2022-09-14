using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;

namespace Sumera_Travel_Corporation.Services
{
    public class HolidayBookingCrudService:IHolidayBookingCrudService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HolidayBookingCrudService(ApplicationDbContext newvariable, IMapper newmapper)
        {
            this._context = newvariable;
            this._mapper = newmapper;
        }
        public async Task<List<HolidayBookingDto>> GetHolidayBookingsAsync()
        {
            try { 
            var a = await _context.HolidayBookings.Include(x => x.customer)
               .Include(y => y.HolidayPackage)
               .ToListAsync();
            var holidaybookingdto = a
                  .Select(d => _mapper.Map<HolidayBookingDto>(d))
                  .ToList();
            return holidaybookingdto;
        }
             catch (Exception ex)
            {
                return null;
            }

        }
       

        public async Task<HolidayBookingDto> GetHolidayBookingAsync(int id)
        {
            var getholidaybookingbyid = await _context.HolidayBookings.FindAsync(id);
            var getholidaybookingbyiddto = _mapper.Map<HolidayBookingDto>(getholidaybookingbyid);
            return getholidaybookingbyiddto;
        }

        public async Task PostHolidayBookingAsync(HolidayBookingDto holidayBookingDto)
        {
            var postholidaybooking = _mapper.Map<HolidayBooking>(holidayBookingDto);
            _context.Add(postholidaybooking);
            await _context.SaveChangesAsync();
        }

        public async Task PutHolidayBookingAsync(HolidayBookingDto holidayBookingDto)
        {
            var putholiday = _mapper.Map<HolidayBooking>(holidayBookingDto);
            _context.HolidayBookings.Update(putholiday);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteHolidayBookingAsync(int id)
        {
            var delholiday = await _context.HolidayBookings.SingleAsync(c => c.HolidayBookingId == id);
            _context.HolidayBookings.Remove(delholiday);
            await _context.SaveChangesAsync();
        }


        

       
       

        

    }
}
