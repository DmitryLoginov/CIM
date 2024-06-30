using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class ACDCTerminal : IdentifiedObject
    {
        private int _sequenceNumber;
        
        public int sequenceNumber
        {
            get => _sequenceNumber;
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("sequenceNumber must be greater than zero");
                }
                else
                {
                    _sequenceNumber = value;
                }
            }
        }
    }
}
