using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaidPlanner.DAL.Models
{
    public class Recompense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Raid")]
        public int RaidId { get; set; }

        public Raid Raid { get; set; }
    }
}
