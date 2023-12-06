using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace soa_ca2.Models
{
    public class Schedule
    {
        [Key]
        public Guid ScheduleID { get; set; }

        [Required]
        public Guid TravelID { get; set; }

        [ForeignKey("TravelID")]
        public Travel Travel { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }
    }
}
