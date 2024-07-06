using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class Conductor : ConductingEquipment
    {
        protected Conductor() { }

        protected Conductor(Guid mRID) : base(mRID) { }
    }
}
