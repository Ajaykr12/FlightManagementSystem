using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
