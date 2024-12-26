using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int PassengerId { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime JourneyDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMode { get; set; }

        [Required]
        public bool IsCancelled { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
    }
}
