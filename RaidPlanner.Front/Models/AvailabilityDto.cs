namespace RaidPlanner.Front.Models
{
    public class AvailabilityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaidSessionId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string RaidSessionDescription { get; set; } = string.Empty; 
    }

}
