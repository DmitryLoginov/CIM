using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class TransformerEnd : IdentifiedObject
    {
        public int endNumber { get; set; }
        public bool grounded { get; set; }
        public BaseVoltage BaseVoltage { get; set; }
        public PhaseTapChanger PhaseTapChanger { get; set; }
        public RatioTapChanger RatioTapChanger { get; set; }
        public Terminal Terminal { get; set; }
        public TransformerMeshImpedance FromMeshImpedance { get; set; }
        public TransformerMeshImpedance ToMeshImpedance { get; set; }
        public TransformerStarImpedance StarImpedance { get; set; }

        protected TransformerEnd() { }
        protected TransformerEnd(Guid mRID) : base(mRID) { }
    }
}
