using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data.Models;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Airline> Airlines { get; set; }
        public  DbSet<Airport> Airports { get; set; }
        public  DbSet<Amenity> Amenities { get; set; }
        public  DbSet<City> Cities { get; set; }
        public  DbSet<Country> Countries { get; set; }
        public  DbSet<Customer> Customers { get; set; }
        public  DbSet<Flight> Flights { get; set; }
        public  DbSet<Hotel> Hotels { get; set; }
        public  DbSet<HotelAmenitiesLink> HotelAmenitiesLinks { get; set; }
        public  DbSet<State> States { get; set; }

        public  DbSet<Locations> Locations { get; set; }

        public DbSet<HolidayPackage> HolidayPackages { get; set; }

        public DbSet<HolidayBooking> HolidayBookings { get; set; }
        

    }
}
