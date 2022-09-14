using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Services
{
    public class HotelCrudService : IHotelCrudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelCrudService(ApplicationDbContext newvariable, IMapper newmapper)
        {
            _context = newvariable;
            _mapper = newmapper;
        }
        public async Task<HotelDto> GetHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            var hoteldto = _mapper.Map<HotelDto>(hotel);
            return hoteldto;
        }

        public async Task<List<HotelDto>> GetHotelsAsync()
        {
            try
            {
                //var hotels = await _context.Hotels.Include("city").ToListAsync();
                var hotels = await _context.Hotels.ToListAsync();
                //var list = new List<HotelDto>();

                //foreach (var hotel in hotels)
                //{
                //    var hoteldtoo = new HotelDto
                //    {
                //        HotelId = hotel.HotelId,
                //        HotelName = hotel.HotelName,
                //        HotelAdress = hotel.HotelAdress,
                //        HotelRent = hotel.HotelRent,
                //        CityRefId = hotel.CityRefId,
                //    };
                //    list.Add(hoteldtoo);
                //}
                //return list;

                var hoteldto = hotels.Select(d=> _mapper.Map<HotelDto>(d)).ToList();
                return hoteldto;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task PostHotelAsync(HotelDto hoteldto)
        {
              var posthotel= _mapper.Map<Hotel>(hoteldto);
                _context.Add(posthotel);
                await _context.SaveChangesAsync();
        }
       
         public async Task DeleteHotelAsync(int id)
        {
            var deletehotel = await _context.Hotels.SingleAsync(c => c.HotelId == id);
             _context.Hotels.Remove(deletehotel);

             await _context.SaveChangesAsync();

         

        }

        public async Task PutHotelAsync( HotelDto hoteldto)
        {
            var puthotel = _mapper.Map<Hotel>(hoteldto);
            _context.Hotels.Update(puthotel);
            await _context.SaveChangesAsync();
        }
    }
}
