﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.ObjectModels
{
    public class ExtensionModel
    {
      
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Raid> Raids { get; set; }
    }
}
