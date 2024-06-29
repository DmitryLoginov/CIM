using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class NoLoadTest : TransformerTest
    {
        public double loss { get; set; }
        public double excitingCurrent { get; set; }
        public double energisedEndVoltage { get; set; }
        public TransformerEndInfo EnergisedEnd { get; set; }
    }
}
