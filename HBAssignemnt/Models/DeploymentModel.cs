using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    public class DeploymentModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientations Orientation { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Orientations
    {
        N,
        E,
        S,
        W
    }
}
