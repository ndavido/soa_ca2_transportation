using soa_ca2.Models.DTOs;

namespace soa_ca2.Models.NewFolder
{
    public class TravelDTO
    {
        public int TravelID { get; set; }
        public string TravelName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        // Including a list of ScheduleDTOs instead of Schedule entities
        public ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
