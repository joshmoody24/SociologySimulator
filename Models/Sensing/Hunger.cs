using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models.Sensing
{
    public class Hunger : Sense
    {
        public override float GetSense()
        {
            return 1f;
        }
    }
}
