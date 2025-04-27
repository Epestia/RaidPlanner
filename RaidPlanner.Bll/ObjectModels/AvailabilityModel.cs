using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.ObjectModels
{
    public class AvailabilityModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaidSessionId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
