using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Substation : EquipmentContainer
    {
        private VoltageLevel[] _voltageLevels = [];
        
        /// <summary>
        /// rf
        /// </summary>
        public Plant Plant { get; set; }
        // TODO: add
        public SubGeographicalRegion Region { get; set; }
        public VoltageLevel[] VoltageLevels
        {
            get => _voltageLevels;
        }
        
        public Substation() { }
        public Substation(Guid mRID) : base(mRID) { }

        public void AddToVoltageLevels(VoltageLevel voltageLevel)
        {
            if (!_voltageLevels.Contains(voltageLevel))
            {
                Array.Resize(ref _voltageLevels, _voltageLevels.Length + 1);
                _voltageLevels[_voltageLevels.Length - 1] = voltageLevel;

                voltageLevel.Substation = this;
            }
        }

        public void RemoveFromVoltageLevels(VoltageLevel voltageLevel)
        {
            if (_voltageLevels.Contains(voltageLevel))
            {
                VoltageLevel[] tempArray = [];

                for (int i = 0; i < _voltageLevels.Length; i++)
                {
                    if (_voltageLevels[i].mRID != voltageLevel.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _voltageLevels[i];
                    }
                }

                _voltageLevels = tempArray;

                voltageLevel.Substation = null;
            }
        }
    }
}
