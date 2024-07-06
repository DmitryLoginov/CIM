using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class FossilSteamSupply : SteamSupply
    {
        protected FossilSteamSupply() { }

        protected FossilSteamSupply(Guid mRID) : base(mRID) { }
    }
}
