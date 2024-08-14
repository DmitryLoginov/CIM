namespace CIM
{
    /// <summary>
    /// Substation.
    /// </summary>
    public class Substation : EquipmentContainer
    {
        private Plant? _plant;
        private SubGeographicalRegion _region;
        private VoltageLevel[] _voltageLevels = [];

        // TODO: rf
        /// <summary>
        /// The power plant to which the group of switchgear belongs.
        /// </summary>
        public Plant? Plant
        {
            get => _plant;
            set
            {
                if (_plant != null)
                {
                    _plant = value;
                    _plant.AddToSubstations(this);
                }
                else
                {
                    if (_plant != null)
                    {
                        _plant.RemoveFromSubstations(this);
                        _plant = null;
                    }
                }
            }
        }
        /// <summary>
        /// Subject of the Russian Federation on whose territory the substation is located.
        /// </summary>
        /// <remarks>
        /// Aggregation.
        /// </remarks>
        public SubGeographicalRegion Region
        {
            get => _region;
            set
            {
                if (_region != null)
                {
                    _region = value;
                    _region.AddToSubstations(this);
                }
                else
                {
                    if (_region != null)
                    {
                        _region.RemoveFromSubstations(this);
                        _region = null;
                    }
                }
            }
        }
        /// <summary>
        /// Switchgear units included in the substation.
        /// </summary>
        public VoltageLevel[] VoltageLevels
        {
            get => _voltageLevels;
        }

        /// <summary>
        /// Substation constructor.
        /// </summary>
        public Substation() : base() { }
        /// <summary>
        /// Substation constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Substation(Guid mRID) : base(mRID) { }

        public void AddToVoltageLevels(VoltageLevel voltageLevel)
        {
            if (!_voltageLevels.Contains(voltageLevel))
            {
                Array.Resize(ref _voltageLevels, _voltageLevels.Length + 1);
                _voltageLevels[_voltageLevels.Length - 1] = voltageLevel;

                //voltageLevel.Substation = this;
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

                //voltageLevel.Substation = null;
            }
        }
    }
}
