using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Bay : EquipmentContainer
    {
        private VoltageLevel _voltageLevel;

        public VoltageLevel VoltageLevel
        {
            get => _voltageLevel;
            set
            {
                if (value == null)
                {
                    throw new FormatException("Bay must be associated with VoltageLevel");
                }
                else
                {
                    _voltageLevel = value;
                }
            }
        }

        /// <summary>
        /// doubtful but okay?
        /// </summary>
        /// <param name="voltageLevel"></param>
        public Bay(VoltageLevel voltageLevel)
        {
            VoltageLevel = voltageLevel;
        }

        public Bay(VoltageLevel voltageLevel, Guid mRID) : base(mRID)
        {
            VoltageLevel = voltageLevel;
        }
    }
}
