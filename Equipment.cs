namespace CIM
{
    /// <summary>
    /// Equipment.
    /// </summary>
    public abstract class Equipment : PowerSystemResource
    {
        private EquipmentContainer? _equipmentContainer;
        private EquipmentContainer[] _additionalEquipmentContainer = [];

        /// <summary>
        /// Equipment container to which the item of equipment belongs.
        /// </summary>
        /// <remarks>
        /// Aggregation.
        /// </remarks>
        public EquipmentContainer? EquipmentContainer
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

        /// <summary>
        /// Additional association of equipment with another container.
        /// </summary>
        /// <remarks>
        /// For example, a switch and other equipment in a bay may be associated 
        /// with a power transmission line, or a section of a power transmission line 
        /// may be associated with substation bays (substations).
        /// </remarks>
        public EquipmentContainer[] AdditionalEquipmentContainer
        {
            get => _additionalEquipmentContainer;
        }

        /// <summary>
        /// The assigned value <see cref="true"/> indicates that the equipment is in operation.
        /// </summary>
        public bool normallyInService { get; set; } = true;

        /// <summary>
        /// Equipment constructor.
        /// </summary>
        protected Equipment() : base() { }
        /// <summary>
        /// Equipment constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
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
