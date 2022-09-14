namespace Sumera_Travel_Corporation.Data.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }

        public DateTime DateOfBirth { get; set; }
         public string? Address1 { get; set; }
        public string? Address2 { get; set; }
       public string? Address3 { get; set; }

        public int PinCode { get; set; }
        public long Telephone1 { get; set; }
        public string? Email1 { get; set; }

        public int CityRefId { get; set; }
    }
}
