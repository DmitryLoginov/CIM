using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class ConductingEquipment : Equipment
    {
        public BaseVoltage BaseVoltage { get; set; }
        public Terminal[] Terminals { get; set; }
    }
}
