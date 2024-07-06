using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class AsynchronousMachine : RotatingMachine
    {
        /// <summary>
        /// rf
        /// </summary>
        public PrimeMover PrimeMover { get; set; }
        
        public AsynchronousMachine() { }
        public AsynchronousMachine(Guid mRID) : base(mRID) { }
    }
}
