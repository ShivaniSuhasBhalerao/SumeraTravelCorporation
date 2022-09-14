namespace Sumera_Travel_Corporation.Data.Dtos
{
    public class HolidayBookingDto
    {
        public int HolidayBookingId { get; set; }

        public int HolidayPackageId { get; set; }
       

        public int CustomerId { get; set; }
      
        public DateTime BookingDate { get; set; }
    }
}
