namespace Sumera_Travel_Corporation.Data.Dtos
{
    public class HolidayPackagesDto
    {
        public int HolidayPackageId { get; set; }
        public int? from_locationRefId { get; set; }
        
       public int to_locationRefId { get; set; }
       
        public int HolidayPackagePrice { get; set; }

        public string? Duration { get; set; }

        public int NumberofGuest { get; set; }

        public int HotelrefId { get; set; }
        

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public string? PackageTitle { get; set; }
        public string? fromLocationName { get; set; }
        public string? toLocatioName { get; set; }
    }
}
