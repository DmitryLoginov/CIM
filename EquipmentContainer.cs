namespace CIM
{
    /// <summary>
    /// Equipment container.
    /// </summary>
    public abstract class EquipmentContainer : ConnectivityNodeContainer
    {
        private Equipment[] _equipments = [];
        private Equipment[] _additionalGroupedEquipment = [];

        /// <summary>
        /// Items of equipment belonging to an equipment container.
        /// </summary>
        public Equipment[] Equipments
        {
            get => _equipments;
        }
        /// <summary>
        /// Items of equipment having an additional association with an equipment container.
        /// </summary>
        public Equipment[] AdditionalGroupedEquipment
        {
            get => _additionalGroupedEquipment;
        }

        /// <summary>
        /// EquipmentContainer constructor.
        /// </summary>
        protected EquipmentContainer() : base() { }
        /// <summary>
        /// EquipmentContainer constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected EquipmentContainer(Guid mRID) : base(mRID) { }

        public void AddToEquipments(Equipment equipment)
        {
            if (!_equipments.Contains(equipment))
            {
                Array.Resize(ref _equipments, _equipments.Length + 1);
                _equipments[_equipments.Length - 1] = equipment;

                //equipment.EquipmentContainer = this;
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

                //equipment.EquipmentContainer = null;
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
