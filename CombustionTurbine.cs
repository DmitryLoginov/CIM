using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class CombustionTurbine : PrimeMover
    {
        public HeatRecoveryBoiler HeatRecoveryBoiler { get; set; }
        
        public CombustionTurbine() { }
        public CombustionTurbine(Guid mRID) : base(mRID) { }
    }
}
