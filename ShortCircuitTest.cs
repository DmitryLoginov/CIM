using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class ShortCircuitTest : TransformerTest
    {
        public double loss { get; set; }
        public double voltage { get; set; }
        public int energizedEndStep { get; set; }
        public int groundedEndStep { get; set; }
        public TransformerEndInfo EnergisedEnd { get; set; }
        public TransformerEndInfo[] GroundedEnds { get; set; }
    }
}
