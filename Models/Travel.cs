using System.ComponentModel.DataAnnotations;

namespace soa_ca2.Models
{
    public class Travel
    {
        [Key]
        public int TravelID { get; set; }

        [Required]
        public string TravelName { get; set; }

        [Required]
        public string StartLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }
        // One-to-Many relationship: One Route can have many Schedules
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
