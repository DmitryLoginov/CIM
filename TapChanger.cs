﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class TapChanger : PowerSystemResource
    {
        protected TapChanger() { }
        protected TapChanger(Guid mRID) : base(mRID) { }
    }
}
