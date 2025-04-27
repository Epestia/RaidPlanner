namespace RaidPlanner.Bll.ObjectModels
{
    public class RaidModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBosses { get; set; }
        public int MinLevel { get; set; }
        public string Difficulty { get; set; }

        public int ExtensionId { get; set; }
        public string ExtensionName { get; set; } 
    }
}
