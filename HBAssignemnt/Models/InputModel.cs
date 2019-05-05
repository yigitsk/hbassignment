using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    public class InputModel
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public List<RoverCommandsModel> CommandSets { get; set; }

    }
}
