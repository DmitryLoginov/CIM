using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class TransformerStarImpedance : IdentifiedObject
    {
        public double r { get; set; }
        public double x { get; set; }
        public TransformerEnd[] TransformerEnd { get; set; }
        public TransformerEndInfo TransformerEndInfo { get; set; }
    }
}
