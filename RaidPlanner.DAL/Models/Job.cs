using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaidPlanner.DAL.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
