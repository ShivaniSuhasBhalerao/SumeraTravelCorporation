namespace Sumera_Travel_Corporation.Data.Dtos
{
    public class AirportDto
    {
        public int AirportId { get; set; }
        public string? AirportName { get; set; }
        public int AirportCode { get; set; }
       public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int PinCode { get; set; }
        public long Telephone1 { get; set; }
        public long Telephone2 { get; set; }
         public string? Email1 { get; set; }
         public string? Email2 { get; set; }

        public int CityRefId { get; set; }
    }
}
