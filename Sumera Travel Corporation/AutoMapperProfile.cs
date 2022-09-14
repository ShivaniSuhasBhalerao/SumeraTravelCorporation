using AutoMapper;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Data.Models;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation
{
    public class AutoMapperProfile:Profile
    {
        
            public AutoMapperProfile()
            {
            CreateMap<Hotel, HotelDto>()
            //.ForMember(a => a.CityName, b => b.MapFrom(c => c.city.CityName))
            .ReverseMap();
            //.ForPath(d => d.city.CityName, b => b.Ignore());

            CreateMap<Customer, CustomerDto>()
                .ReverseMap();

           
            CreateMap<Airport, AirportDto>()
              .ReverseMap();
            CreateMap<Locations, LocationDto>()
                .ReverseMap();
            CreateMap<HolidayBooking, HolidayBookingDto>()
                .ReverseMap();
            CreateMap<HolidayPackage, HolidayPackagesDto>()
                .ForMember(a => a.fromLocationName, b => b.MapFrom(c => c.fromlocation.LocationName))
                .ForMember(a => a.toLocatioName, b => b.MapFrom(c => c.tolocation.LocationName))
                .ReverseMap()
            .ForPath(d => d.fromlocation.LocationName, b => b.Ignore())
            .ForPath(d => d.tolocation.LocationName, b => b.Ignore());
        }
    }
}

