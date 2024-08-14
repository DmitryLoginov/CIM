namespace CIM
{
    /// <summary>
    /// Switchgear.
    /// </summary>
    public class VoltageLevel : EquipmentContainer
    {
        private BaseVoltage _baseVoltage;
        private Bay[] _bays = [];
        private Substation _substation;

        /// <summary>
        /// Standard rated voltage of switchgear.
        /// </summary>
        public BaseVoltage BaseVoltage
        {
            get => _baseVoltage;
            set
            {
                if (value != null)
                {
                    _baseVoltage = value;
                    _baseVoltage.AddToVoltageLevel(this);
                }
                else
                {
                    // TODO: error: VoltageLevel without a BaseVoltage
                    _baseVoltage.RemoveFromVoltageLevel(this);
                    _baseVoltage = null;
                }
            }
        }
        /// <summary>
        /// Switchgear connections.
        /// </summary>
        public Bay[] Bays
        {
            get => _bays;
        }
        /// <summary>
        /// Substation, which includes a switchgear.
        /// </summary>
        /// <remarks>
        /// Aggregation.
        /// </remarks>
        public Substation Substation
        {
            get => _substation;
            set
            {
                if (value != null)
                {
                    _substation = value;
                    _substation.AddToVoltageLevels(this);
                }
                else
                {
                    // TODO: error: VoltageLevel without a Substation
                    _substation.RemoveFromVoltageLevels(this);
                    _substation = null;
                }
            }
        }
        
        /// <summary>
        /// VoltageLevel constructor.
        /// </summary>
        public VoltageLevel() : base() { }
        /// <summary>
        /// VoltageLevel constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public VoltageLevel(Guid mRID) : base(mRID) { }
        /// <summary>
        /// VoltageLevel constructor.
        /// </summary>
        /// <param name="substation"><inheritdoc cref="Substation" path="/summary/node()" /></param>
        public VoltageLevel(Substation substation) : this(Guid.NewGuid(), substation) { }
        /// <summary>
        /// VoltageLevel constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="substation"><inheritdoc cref="Substation" path="/summary/node()" /></param>
        public VoltageLevel(Guid mRID, Substation substation) : base(mRID)
        {
            Substation = substation;
        }

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
