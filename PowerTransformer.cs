using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class PowerTransformer : ConductingEquipment
    {
        public string vectorGroup { get; set; }
        public PowerTransformerEnd[] PowerTransformerEnd { get; set; }
    }
}
