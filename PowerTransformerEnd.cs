using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class PowerTransformerEnd : TransformerEnd
    {
        public double b { get; set; }
        public WindingConnection connectionKind { get; set; }
        public double g { get; set; }
        public int phaseAngleClock { get; set; }
        public double r { get; set; }
        public double ratedS { get; set; }
        public double ratedU { get; set; }
        public double x { get; set; }
        public PowerTransformer PowerTransformer { get; set; }
        public TransformerEndInfo TransformerEndInfo { get; set; }
    }
}
