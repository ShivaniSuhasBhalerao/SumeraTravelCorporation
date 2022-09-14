using Sumera_Travel_Corporation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sumera_Travel_Corporation.Data.Models
{
    [Table(nameof(HolidayBooking),Schema= "MasterData")]
    
    public class HolidayBooking
    {
        [Key]
        public int HolidayBookingId { get; set; }

        public int HolidayPackageId { get; set; }
        [ForeignKey("HolidayPackageId")]
        public HolidayPackage? HolidayPackage { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? customer { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
