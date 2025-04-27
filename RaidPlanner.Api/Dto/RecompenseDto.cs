namespace RaidPlanner.Api.Dtos
{
    public class RecompenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RaidId { get; set; }
    }
}
