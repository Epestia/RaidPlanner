using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.ObjectModels
{
    public class RecompenseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RaidId { get; set; }
    }
}
