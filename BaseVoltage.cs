using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class BaseVoltage : IdentifiedObject
    {
        private int _nominalVoltage;

        private ConductingEquipment[] _conductingEquipment = [];

        private TransformerEnd[] _transformerEnd = [];

        private VoltageLevel[] _voltageLevel = [];

        /// <summary>
        /// rf
        /// </summary>
        public bool isDC { get; set; } = false;

        public int nominalVoltage
        {
            get
            {
                return _nominalVoltage;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("nominalVoltage must be zero or positive value");
                }
                else
                {
                    _nominalVoltage = value;
                }
            }
        }

        public ConductingEquipment[] ConductingEquipment
        {
            get => _conductingEquipment;
        }

        public TransformerEnd[] TransformerEnd
        {
            get => _transformerEnd;
        }

        public VoltageLevel[] VoltageLevel
        {
            get => _voltageLevel;
        }

        public BaseVoltage() { }

        public BaseVoltage(Guid mRID) : base(mRID) { }

        public void AddToConductingEquipment(ConductingEquipment conductingEquipment)
        {
            if (!_conductingEquipment.Contains(conductingEquipment))
            {
                Array.Resize(ref _conductingEquipment, _conductingEquipment.Length + 1);
                _conductingEquipment[_conductingEquipment.Length - 1] = conductingEquipment;

                conductingEquipment.BaseVoltage = this;
            }
        }

        public void RemoveFromPowerSystemResource(ConductingEquipment conductingEquipment)
        {
            if (_conductingEquipment.Contains(conductingEquipment))
            {
                ConductingEquipment[] tempArray = [];

                for (int i = 0; i < _conductingEquipment.Length; i++)
                {
                    if (_conductingEquipment[i].mRID != conductingEquipment.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _conductingEquipment[i];
                    }
                }

                _conductingEquipment = tempArray;

                conductingEquipment.BaseVoltage = null;
            }
        }

        public void AddToTransformerEnd(TransformerEnd transformerEnd)
        {
            if (!_transformerEnd.Contains(transformerEnd))
            {
                Array.Resize(ref _transformerEnd, _transformerEnd.Length + 1);
                _transformerEnd[_transformerEnd.Length - 1] = transformerEnd;

                transformerEnd.BaseVoltage = this;
            }
        }

        public void RemoveFromTransformerEnd(TransformerEnd transformerEnd)
        {
            if (_transformerEnd.Contains(transformerEnd))
            {
                TransformerEnd[] tempArray = [];

                for (int i = 0; i < _transformerEnd.Length; i++)
                {
                    if (_transformerEnd[i].mRID != transformerEnd.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _transformerEnd[i];
                    }
                }

                _transformerEnd = tempArray;

                transformerEnd.BaseVoltage = null;
            }
        }

        public void AddToVoltageLevel(VoltageLevel voltageLevel)
        {
            if (!_voltageLevel.Contains(voltageLevel))
            {
                Array.Resize(ref _voltageLevel, _voltageLevel.Length + 1);
                _voltageLevel[_voltageLevel.Length - 1] = voltageLevel;

                voltageLevel.BaseVoltage = this;
            }
        }

        public void RemoveFromVoltageLevel(VoltageLevel voltageLevel)
        {
            if (_voltageLevel.Contains(voltageLevel))
            {
                VoltageLevel[] tempArray = [];

                for (int i = 0; i < _voltageLevel.Length; i++)
                {
                    if (_voltageLevel[i].mRID != voltageLevel.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _voltageLevel[i];
                    }
                }

                _voltageLevel = tempArray;

                voltageLevel.BaseVoltage = null;
            }
        }
    }
}
