using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.ObjectModels
{
    public class CharacterModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }
    }
}

