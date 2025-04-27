namespace RaidPlanner.Bll.ObjectModels
{
    public class RaidSessionDto
    {
        public int Id { get; set; }
        public int RaidId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Description { get; set; }
    }
}
