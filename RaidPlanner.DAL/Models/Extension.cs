using System.ComponentModel.DataAnnotations;

namespace RaidPlanner.DAL.Models
{
    public class Extension
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public ICollection<Raid> Raids { get; set; }
    }
}
