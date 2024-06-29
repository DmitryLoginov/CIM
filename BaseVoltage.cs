using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class BaseVoltage : IdentifiedObject
    {
        public bool isDC { get; set; }
        public double nominalVoltage { get; set; }
        public ConductingEquipment[] ConductingEquipment { get; set; }
        public TransformerEnd[] TransformerEnd { get; set; }
    }
}
