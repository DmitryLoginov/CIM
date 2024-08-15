namespace CIM
{
    /// <summary>
    /// Power plant.
    /// </summary>
    public class Plant : EquipmentContainer
    {
        private SubGeographicalRegion _region;
        private Substation[] _substations = [];

        // TODO: rf
        /// <summary>
        /// Subject of the Russian Federation on the territory of which the power plant is located.
        /// </summary>
        public SubGeographicalRegion Region
        {
            get => _region;
            set
            {
                if (_region != null)
                {
                    _region = value;
                    _region.AddToPlants(this);
                }
                else
                {
                    if (_region != null)
                    {
                        _region.RemoveFromPlants(this);
                        _region = null;
                    }
                }
            }
        }
        // TODO: rf
        /// <summary>
        /// Power plant switchgear groups.
        /// </summary>
        public Substation[] Substations
        {
            get => _substations;
        }

        /// <summary>
        /// Plant constructor.
        /// </summary>
        public Plant() : base() { }
        /// <summary>
        /// Plant constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Plant(Guid mRID) : base(mRID) { }

        public void AddToSubstations(Substation substation)
        {
            if (!_substations.Contains(substation))
            {
                Array.Resize(ref _substations, _substations.Length + 1);
                _substations[^1] = substation;

                //substation.Plant = this;
            }
        }

        public void RemoveFromSubstations(Substation substation)
        {
            if (_substations.Contains(substation))
            {
                Substation[] tempArray = [];

                for (int i = 0; i < _substations.Length; i++)
                {
                    // TODO: name and nameType
                    if (_substations[i].mRID != substation.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[^1] = _substations[i];
                    }
                }

                _substations = tempArray;

                //substation.Plant = null;
            }
        }
    }
}
