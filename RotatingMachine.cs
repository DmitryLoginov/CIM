using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class RotatingMachine : RegulatingCondEq
    {
        public GeneratingUnit GeneratingUnit { get; set; }
        
        protected RotatingMachine() { }
        protected RotatingMachine(Guid mRID) : base(mRID) { }
    }
}
