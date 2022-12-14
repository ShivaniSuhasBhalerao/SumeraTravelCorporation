// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sumera_Travel_Corporation.Models
{
    [Table(nameof(Hotel), Schema = "MasterData")]
    public class Hotel
    {
     

        [Key]
        public int HotelId { get; set; }
    
        [StringLength(50)]
      
        public string HotelName { get; set; }
       
        [StringLength(50)]

        public string HotelAdress { get; set; }

     
        public string Stars { get; set; }

        public int HotelRent { get; set; }
        public int CityRefId { get; set; }

        [ForeignKey("CityRefId")]
        
        public  City city { get; set; }
       
     
    }
}