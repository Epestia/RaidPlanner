namespace RaidPlanner.Api.Dto
{
    public class AvailabilityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaidSessionId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
