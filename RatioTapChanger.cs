using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class RatioTapChanger : TapChanger
    {
        public TransformerEnd TransformerEnd { get; set; }

        public RatioTapChanger() { }
        public RatioTapChanger(Guid mRID) : base(mRID) { }
        public RatioTapChanger(TransformerEnd transformerEnd)
        {
            TransformerEnd = transformerEnd;
        }
        public RatioTapChanger(Guid mRID, TransformerEnd transformerEnd) : base(mRID)
        {
            TransformerEnd = transformerEnd;
        }
    }
}
