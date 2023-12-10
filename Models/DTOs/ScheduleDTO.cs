namespace soa_ca2.Models.DTOs
{
    public class ScheduleDTO
    {
        public int ScheduleID { get; set; }
        public int TravelID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
