using Sumera_Travel_Corporation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sumera_Travel_Corporation.Data.Models
{
    [Table(nameof(HolidayPackage), Schema = "MasterData")]
    public class HolidayPackage
    {
        [Key]
        public int HolidayPackageId { get; set; }
         public int? from_locationRefId { get; set; }
        [ForeignKey("from_locationRefId")]
        public Locations? fromlocation { get; set; }


        public int to_locationRefId { get; set; }
        [ForeignKey("to_locationRefId")]
        public Locations? tolocation { get; set; }
        public int HolidayPackagePrice { get; set; }

        public string? Duration { get; set; }

        public int NumberofGuest { get; set; }

        public int HotelrefId { get; set; }
        [ForeignKey("HotelrefId")]

        public Hotel? hotel { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public string? PackageTitle { get; set; }
     
    }
}
