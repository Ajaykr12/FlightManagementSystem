using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentificationType { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentificationNumber { get; set; }
    }
}
