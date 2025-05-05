namespace RaidPlanner.Front.Models
{
    public class RaidSessionDto
    {
        public int Id { get; set; }
        public int RaidId { get; set; }
        public DateTime Date { get; set; } // ok pour <InputDate>
        public TimeSpan StartTime { get; set; } // ok avec conversion string
        public TimeSpan EndTime { get; set; }   // idem
        public string? Description { get; set; }
    }


}
