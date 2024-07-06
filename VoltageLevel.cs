using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class VoltageLevel : EquipmentContainer
    {
        private Bay[] _bays = [];
        
        public BaseVoltage BaseVoltage { get; set; }
        public Bay[] Bays
        {
            get => _bays;
        }
        // TODO: ctor
        public Substation Substation { get; set; }
        
        public VoltageLevel() { }
        public VoltageLevel(Guid mRID) : base(mRID) { }

        public void AddToBays(Bay bay)
        {
            if (!_bays.Contains(bay))
            {
                Array.Resize(ref _bays, _bays.Length + 1);
                _bays[_bays.Length - 1] = bay;

                bay.VoltageLevel = this;
            }
        }

        public void RemoveFromBays(Bay bay)
        {
            if (_bays.Contains(bay))
            {
                Bay[] tempArray = [];

                for (int i = 0; i < _bays.Length; i++)
                {
                    if (_bays[i].mRID != bay.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _bays[i];
                    }
                }

                _bays = tempArray;

                bay.VoltageLevel = null;
            }
        }
    }
}
