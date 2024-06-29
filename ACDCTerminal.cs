using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class ACDCTerminal : IdentifiedObject
    {
        public int sequenceNumber { get; set; }
    }
}
