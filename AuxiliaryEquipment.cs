using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class AuxiliaryEquipment : Equipment
    {
        //private Terminal _terminal;

        // TODO: add
        public Terminal Terminal { get; set; }
        //{
        //    get => _terminal;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new FormatException("AuxiliaryEquipment must be associated with Terminal of ConductingEquipment");
        //        }
        //        else
        //        {
        //            _terminal = value;
        //        }
        //    }
        //}

        protected AuxiliaryEquipment() { }
        protected AuxiliaryEquipment(Guid mRID) : base(mRID) { }
        protected AuxiliaryEquipment(Terminal terminal)
        {
            Terminal = terminal;
        }
        protected AuxiliaryEquipment(Terminal terminal, Guid mRID) : base(mRID)
        {
            Terminal = terminal;
        }


    }
}
