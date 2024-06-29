using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class TransformerMeshImpedance : IdentifiedObject
    {
        public double r { get; set; }
        public double x { get; set; }
        public TransformerEnd FromTransformerEnd { get; set; }
        public TransformerEnd[] ToTransformerEnd { get; set; }
    }
}
