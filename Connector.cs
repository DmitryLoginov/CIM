using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class Connector : ConductingEquipment
    {
        protected Connector() { }

        protected Connector(Guid mRID) : base(mRID) { }
    }
}
