namespace Sumera_Travel_Corporation.Data.Dtos
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Stars { get; set; }
        public string? HotelAdress { get; set; }
        public int HotelRent { get; set; }
        public int CityRefId { get; set; }
        //public string? CityName { get; set; }

    }
}
