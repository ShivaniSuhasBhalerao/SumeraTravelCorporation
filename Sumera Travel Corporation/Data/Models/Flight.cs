
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sumera_Travel_Corporation.Models
{
    [Table(nameof(Flight), Schema = "MasterData")]
    public partial class Flight
    {
        [Key]
        public int FlightId { get; set; }
      
        [StringLength(50)]
     
        public string? FlightCode { get; set; }
        
        
      
      
        [StringLength(50)]
      
        public string? Address1 { get; set; }
    
        [StringLength(50)]
    
        public string? Address2 { get; set; }
     
        public int PinCode { get; set; }
        public long Telephone1 { get; set; }
        public long Telephone2 { get; set; }
     
        [StringLength(50)]
      
        public string? Email1 { get; set; }
      
        [StringLength(50)]
        
        public string? Email2 { get; set; }
     
        public string? Location { get; set; }
        public int AirlineRefId { get; set; }
        [ForeignKey("AirlineRefId")]
        public  Airline? airline { get; set; }
        
           public int CityRefId { get; set; }
        [ForeignKey("CityRefId")]
        public  City? city { get; set; }
        
        public int FromAirportRefId { get; set; }
        [ForeignKey("FromAirportRefId")]
        public  Airport? fromAirport { get; set; }


        public int ToAirportRefId { get; set; }
        [ForeignKey("ToAirportRefId")]
        public  Airport? toAirport { get; set; }
    }
}