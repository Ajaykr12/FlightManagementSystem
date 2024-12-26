namespace FlightManagementSystem.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public int FlightId { get; set; }
    }
}
