using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    public class RoverCommandsModel
    {
        public DeploymentModel DeployLocation { get; set; }
        public String Command { get; set; }
    }
}
