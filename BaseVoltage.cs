using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class BaseVoltage : IdentifiedObject
    {
        private int _nominalVoltage;

        public bool isDC { get; set; } = false;

        public int nominalVoltage
        {
            get
            {
                return _nominalVoltage;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("nominalVoltage must be zero or positive value");
                }
                else
                {
                    _nominalVoltage = value;
                }
            }
        }

        public ConductingEquipment[] ConductingEquipment { get; set; }
        public TransformerEnd[] TransformerEnd { get; set; }
    }
}
