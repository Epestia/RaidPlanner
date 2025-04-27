using RaidPlanner.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.ObjectModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Mail { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

    }
}
