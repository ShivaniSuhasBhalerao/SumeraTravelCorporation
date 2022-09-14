using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sumera_Travel_Corporation.Data.Models
{
    [Table(nameof(Locations), Schema = "MasterData")]
    public class Locations
    {
        [Key]
        public int LocationId { get; set; }
        [StringLength(50)]
      public string? LocationName { get; set; }
    }
}
