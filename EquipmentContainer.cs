using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class EquipmentContainer : ConnectivityNodeContainer
    {
        private Equipment[] _equipments = [];
        private Equipment[] _additionalGroupedEquipment = [];

        public Equipment[] Equipments
        {
            get => _equipments;
        }
        public Equipment[] AdditionalGroupedEquipment
        {
            get => _additionalGroupedEquipment;
        }
        
        protected EquipmentContainer() { }
        protected EquipmentContainer(Guid mRID) : base(mRID) { }

        public void AddToEquipments(Equipment equipment)
        {
            if (!_equipments.Contains(equipment))
            {
                Array.Resize(ref _equipments, _equipments.Length + 1);
                _equipments[_equipments.Length - 1] = equipment;

                equipment.EquipmentContainer = this;
            }
        }

        public void RemoveFromEquipments(Equipment equipment)
        {
            if (_equipments.Contains(equipment))
            {
                Equipment[] tempArray = [];

                for (int i = 0; i < _equipments.Length; i++)
                {
                    if (_equipments[i].mRID != equipment.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _equipments[i];
                    }
                }

                _equipments = tempArray;

                equipment.EquipmentContainer = null;
            }
        }

        public void AddToAdditionalGroupedEquipment(Equipment equipment)
        {
            if (!_additionalGroupedEquipment.Contains(equipment))
            {
                Array.Resize(ref _additionalGroupedEquipment, _additionalGroupedEquipment.Length + 1);
                _additionalGroupedEquipment[_additionalGroupedEquipment.Length - 1] = equipment;

                equipment.AddToAdditionalEquipmentContainer(this);
            }
        }

        public void RemoveFromAdditionalGroupedEquipment(Equipment equipment)
        {
            if (_additionalGroupedEquipment.Contains(equipment))
            {
                Equipment[] tempArray = [];

                for (int i = 0; i < _additionalGroupedEquipment.Length; i++)
                {
                    if (_additionalGroupedEquipment[i].mRID != equipment.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _additionalGroupedEquipment[i];
                    }
                }

                _additionalGroupedEquipment = tempArray;

                equipment.RemoveFromAdditionalEquipmentContainer(this);
            }
        }
    }
}
