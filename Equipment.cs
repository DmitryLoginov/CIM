using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class Equipment : PowerSystemResource
    {
        private EquipmentContainer _equipmentContainer;

        private EquipmentContainer[] _additionalEquipmentContainer = [];
        
        // TODO: remove from equipmentContainer and other containers
        public EquipmentContainer EquipmentContainer
        {
            get => _equipmentContainer;
            set
            {
                if (_equipmentContainer != null)
                {
                    _equipmentContainer = value;
                    _equipmentContainer.AddToEquipments(this);
                }
                else
                {
                    _equipmentContainer.RemoveFromEquipments(this);
                    _equipmentContainer = null;
                }
            }
        }
        public EquipmentContainer[] AdditionalEquipmentContainer
        {
            get => _additionalEquipmentContainer;
        }
        public bool normallyInService { get; set; } = true;

        protected Equipment() { }
        protected Equipment(Guid mRID) : base(mRID) { }

        public void AddToAdditionalEquipmentContainer(EquipmentContainer equipmentContainer)
        {
            if (!_additionalEquipmentContainer.Contains(equipmentContainer))
            {
                Array.Resize(ref _additionalEquipmentContainer, _additionalEquipmentContainer.Length + 1);
                _additionalEquipmentContainer[_additionalEquipmentContainer.Length - 1] = equipmentContainer;

                equipmentContainer.AddToAdditionalGroupedEquipment(this);
            }
        }

        public void RemoveFromAdditionalEquipmentContainer(EquipmentContainer equipmentContainer)
        {
            if (_additionalEquipmentContainer.Contains(equipmentContainer))
            {
                EquipmentContainer[] tempArray = [];

                for (int i = 0; i < _additionalEquipmentContainer.Length; i++)
                {
                    if (_additionalEquipmentContainer[i].mRID != equipmentContainer.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _additionalEquipmentContainer[i];
                    }
                }

                _additionalEquipmentContainer = tempArray;

                equipmentContainer.RemoveFromAdditionalGroupedEquipment(this);
            }
        }
    }
}
