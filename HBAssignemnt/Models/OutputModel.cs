using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    public class OutputModel
    {
        public List<RoverStatus> statutes { get; set; }

        public OutputModel()
        {
            this.statutes = new List<RoverStatus>();
        }
    }

    public class RoverStatus
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientations orientation { get; set; }
    }
}
