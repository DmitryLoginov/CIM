using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class ConductingEquipment : Equipment
    {
        private BaseVoltage _baseVoltage;

        private Terminal[] _terminals = [];

        public BaseVoltage BaseVoltage
        {
            get => _baseVoltage;
            set
            {
                _baseVoltage = value;
                _baseVoltage.AddToConductingEquipment(this);
            }
        }

        public Terminal[] Terminals
        {
            get => _terminals;
        }
        protected ConductingEquipment() { }

        protected ConductingEquipment(Guid mRID) : base(mRID) { }

        protected ConductingEquipment(int numberOfTerminals)
        {
            if (numberOfTerminals == 0)
            {
                throw new ArgumentException("ConductingEquipment must have one or more terminals");
            }
            else
            {
                for (int i = 0; i <= numberOfTerminals; i++)
                {
                    var terminal = new Terminal(this);

                    Array.Resize(ref _terminals, _terminals.Length + 1);
                    _terminals[_terminals.Length - 1] = terminal;
                }
            }
        }

        protected ConductingEquipment(int numberOfTerminals, Guid mRID) : base(mRID)
        {
            if (numberOfTerminals == 0)
            {
                throw new ArgumentException("ConductingEquipment must have one or more terminals");
            }
            else
            {
                for (int i = 0; i <= numberOfTerminals; i++)
                {
                    var terminal = new Terminal(this);

                    Array.Resize(ref _terminals, _terminals.Length + 1);
                    _terminals[_terminals.Length - 1] = terminal;
                }
            }
        }
    }
}
