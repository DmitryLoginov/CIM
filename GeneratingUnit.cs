using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class GeneratingUnit : Equipment
    {
        public RotatingMachine RotatingMachine { get; set; }

        protected GeneratingUnit() { }
        protected GeneratingUnit(Guid mRID) : base(mRID) { }
    }
}
