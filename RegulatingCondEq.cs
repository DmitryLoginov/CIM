using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class RegulatingCondEq : ConductingEquipment
    {
        protected RegulatingCondEq() { }

        protected RegulatingCondEq(Guid mRID) : base(mRID) { }

    }
}
