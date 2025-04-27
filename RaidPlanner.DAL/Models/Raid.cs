using RaidPlanner.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Raid
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfBosses { get; set; }
    public int MinLevel { get; set; }
    public string Difficulty { get; set; }


    public int ExtensionId { get; set; }
    public Extension Extension { get; set; }
}
