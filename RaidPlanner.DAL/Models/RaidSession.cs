using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.DAL.Models
{
    public class RaidSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Raid")]
        public int RaidId { get; set; }

        public Raid Raid { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
