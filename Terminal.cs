using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Terminal : ACDCTerminal
    {
        public ConductingEquipment ConductingEquipment { get; set; }
        public TransformerEnd[] TransformerEnd { get; set; }
    }
}
