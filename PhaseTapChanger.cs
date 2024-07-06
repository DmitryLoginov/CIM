using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class PhaseTapChanger : TapChanger
    {
        public TransformerEnd TransformerEnd { get; set; }

        protected PhaseTapChanger() { }
        protected PhaseTapChanger(Guid mRID) : base(mRID) { }
        protected PhaseTapChanger(TransformerEnd transformerEnd)
        {
            TransformerEnd = transformerEnd;
        }
        protected PhaseTapChanger(Guid mRID, TransformerEnd transformerEnd) : base(mRID)
        {
            TransformerEnd = transformerEnd;
        }
    }
}
