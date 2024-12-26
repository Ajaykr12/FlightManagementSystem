namespace FlightManagementSystem.DTO
{
    public class ReservationDTO
    {
        public int PassengerId { get; set; }

        public int FlightId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime JourneyDate { get; set; }

        public string PaymentMode { get; set; }

        public bool IsCancelled { get; set; }

        public decimal Amount { get; set; }
    }
}
