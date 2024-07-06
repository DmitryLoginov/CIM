using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Terminal : ACDCTerminal
    {
        private AuxiliaryEquipment[] _auxiliaryEquipment = [];
        private TransformerEnd[] _transformerEnd = [];
        
        public AuxiliaryEquipment[] AuxiliaryEquipment
        {
            get => _auxiliaryEquipment;
        }
        public ConductingEquipment ConductingEquipment { get; set; }
        public ConnectivityNode ConnectivityNode { get; set; }
        public TransformerEnd[] TransformerEnd
        {
            get => _transformerEnd;
        }

        public Terminal(ConductingEquipment conductingEquipment)
        {
            ConductingEquipment = conductingEquipment;
            if (conductingEquipment.Terminals.Length != 0)
            {
                sequenceNumber = conductingEquipment.Terminals.Max(terminal => terminal.sequenceNumber) + 1;
            }
            else
            {
                sequenceNumber = 1;
            }
        }
        public Terminal(ConductingEquipment conductingEquipment, Guid mRID) : base(mRID)
        {
            ConductingEquipment = conductingEquipment;
            if (conductingEquipment.Terminals.Length != 0)
            {
                sequenceNumber = conductingEquipment.Terminals.Max(terminal => terminal.sequenceNumber) + 1;
            }
            else
            {
                sequenceNumber = 1;
            }
        }
        public Terminal(int sequenceNumber, ConductingEquipment conductingEquipment) : base(sequenceNumber)
        {
            ConductingEquipment = conductingEquipment;
        }
        public Terminal(int sequenceNumber, ConductingEquipment conductingEquipment, Guid mRID) : base(sequenceNumber, mRID)
        {
            ConductingEquipment = conductingEquipment;
        }

        public void AddToAuxiliaryEquipment(AuxiliaryEquipment auxiliaryEquipment)
        {
            if (!_auxiliaryEquipment.Contains(auxiliaryEquipment))
            {
                Array.Resize(ref _auxiliaryEquipment, _auxiliaryEquipment.Length + 1);
                _auxiliaryEquipment[_auxiliaryEquipment.Length - 1] = auxiliaryEquipment;

                auxiliaryEquipment.Terminal = this;
            }
        }

        public void RemoveFromAuxiliaryEquipment(AuxiliaryEquipment auxiliaryEquipment)
        {
            if (_auxiliaryEquipment.Contains(auxiliaryEquipment))
            {
                AuxiliaryEquipment[] tempArray = [];

                for (int i = 0; i < _auxiliaryEquipment.Length; i++)
                {
                    if (_auxiliaryEquipment[i].mRID != auxiliaryEquipment.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _auxiliaryEquipment[i];
                    }
                }

                _auxiliaryEquipment = tempArray;

                auxiliaryEquipment.Terminal = null;
            }
        }

        public void AddToTransformerEnd(TransformerEnd transformerEnd)
        {
            if (!_transformerEnd.Contains(transformerEnd))
            {
                Array.Resize(ref _transformerEnd, _transformerEnd.Length + 1);
                _transformerEnd[_transformerEnd.Length - 1] = transformerEnd;

                transformerEnd.Terminal = this;
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

                transformerEnd.Terminal = null;
            }
        }
    }
}
