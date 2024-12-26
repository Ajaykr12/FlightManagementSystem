using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Source { get; set; }

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int AvailableSeats { get; set; }

        [Required]
        public bool IsCancelled { get; set; }
    }
}
