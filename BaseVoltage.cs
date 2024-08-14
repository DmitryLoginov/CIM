namespace CIM
{
    /// <summary>
    /// Standard rated voltage.
    /// </summary>
    public class BaseVoltage : IdentifiedObject
    {
        private int? _nominalVoltage;
        private ConductingEquipment[] _conductingEquipment = [];
        private TransformerEnd[] _transformerEnds = [];
        private VoltageLevel[] _voltageLevel = [];

        /// <summary>
        /// Indication that the rated voltage value is DC voltage.
        /// </summary>
        /// <remarks>
        /// rf
        /// </remarks>
        public bool isDC { get; set; } = false;

        /// <summary>
        /// Rated voltage value, kV.
        /// </summary>
        public int? nominalVoltage
        {
            get => _nominalVoltage;
            set
            {
                // TODO: null
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

        /// <summary>
        /// Electrically conductive equipment related to standard voltage rating.
        /// </summary>
        public ConductingEquipment[] ConductingEquipment
        {
            get => _conductingEquipment;
        }

        /// <summary>
        /// Transformer bushings related to standard rated voltage.
        /// </summary>
        public TransformerEnd[] TransformerEnds
        {
            get => _transformerEnds;
        }

        /// <summary>
        /// Switchgears related to standard rated voltage.
        /// </summary>
        public VoltageLevel[] VoltageLevel
        {
            get => _voltageLevel;
        }

        /// <summary>
        /// BaseVoltage constructor.
        /// </summary>
        public BaseVoltage() : this(Guid.NewGuid(), null) { }

        /// <summary>
        /// BaseVoltage constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public BaseVoltage(Guid mRID) : this(mRID, null) { }
        /// <summary>
        /// BaseVoltage constructor.
        /// </summary>
        /// <param name="nominalVoltage"><inheritdoc cref="nominalVoltage" path="/summary/node()" /></param>
        public BaseVoltage(int? nominalVoltage) : this(Guid.NewGuid(), nominalVoltage) { }
        /// <summary>
        /// BaseVoltage constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="nominalVoltage"><inheritdoc cref="nominalVoltage" path="/summary/node()" /></param>
        public BaseVoltage(Guid mRID, int? nominalVoltage) : base(mRID)
        {
            this.nominalVoltage = nominalVoltage;
        }

        public void AddToConductingEquipment(ConductingEquipment conductingEquipment)
        {
            if (!_conductingEquipment.Contains(conductingEquipment))
            {
                Array.Resize(ref _conductingEquipment, _conductingEquipment.Length + 1);
                _conductingEquipment[_conductingEquipment.Length - 1] = conductingEquipment;

                //conductingEquipment.BaseVoltage = this;
            }
        }

        public void RemoveFromConductingEquipment(ConductingEquipment conductingEquipment)
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

                //conductingEquipment.BaseVoltage = null;
            }
        }

        public void AddToTransformerEnd(TransformerEnd transformerEnd)
        {
            if (!_transformerEnds.Contains(transformerEnd))
            {
                Array.Resize(ref _transformerEnds, _transformerEnds.Length + 1);
                _transformerEnds[_transformerEnds.Length - 1] = transformerEnd;

                //transformerEnd.BaseVoltage = this;
            }
        }

        public void RemoveFromTransformerEnd(TransformerEnd transformerEnd)
        {
            if (_transformerEnds.Contains(transformerEnd))
            {
                TransformerEnd[] tempArray = [];

                for (int i = 0; i < _transformerEnds.Length; i++)
                {
                    if (_transformerEnds[i].mRID != transformerEnd.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _transformerEnds[i];
                    }
                }

                _transformerEnds = tempArray;

                //transformerEnd.BaseVoltage = null;
            }
        }

        public void AddToVoltageLevel(VoltageLevel voltageLevel)
        {
            if (!_voltageLevel.Contains(voltageLevel))
            {
                Array.Resize(ref _voltageLevel, _voltageLevel.Length + 1);
                _voltageLevel[_voltageLevel.Length - 1] = voltageLevel;

                //voltageLevel.BaseVoltage = this;
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

                //voltageLevel.BaseVoltage = null;
            }
        }
    }
}
