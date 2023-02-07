using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    public struct Relationship
    {
        public Character Other { get; set; }
        public float Strength { get; set; }
        public float Friendliness { get; set; }
    }
}
