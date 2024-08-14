namespace CIM
{
    /// <summary>
    /// Pole of electrically conductive equipment.
    /// </summary>
    /// <remarks>
    /// A model element to represent an electrical connection to electrically conductive equipment.
    /// </remarks>
    public class Terminal : ACDCTerminal
    {
        private AuxiliaryEquipment[] _auxiliaryEquipment = [];
        private ConductingEquipment _conductingEquipment;
        private ConnectivityNode _connectivityNode;
        private TransformerEnd[] _transformerEnd = [];

        /// <summary>
        /// Auxiliary equipment connected to a pole of electrically conductive equipment.
        /// </summary>
        public AuxiliaryEquipment[] AuxiliaryEquipment
        {
            get => _auxiliaryEquipment;
        }
        /// <summary>
        /// Electrically conductive equipment to which the pole belongs.
        /// </summary>
        public ConductingEquipment ConductingEquipment
        {
            get => _conductingEquipment;
            set
            {
                if (value != null)
                {
                    _conductingEquipment = value;
                    value.AddToTerminals(this);
                }
                else
                {
                    // TODO: error: Terminal without ConductingEquipment
                    _conductingEquipment.RemoveFromTerminals(this);
                    _conductingEquipment = null;
                }
            }
        }
        /// <summary>
        /// Pole connection unit.
        /// </summary>
        public ConnectivityNode ConnectivityNode
        {
            get => _connectivityNode;
            set
            {
                if (value != null)
                {
                    _connectivityNode = value;
                    value.AddToTerminals(this);
                }
                else
                {
                    // TODO: error: Terminal without ConnectivityNode
                    _connectivityNode.RemoveFromTerminals(this);
                    _connectivityNode = null;
                }
            }
        }
        /// <summary>
        /// Transformer terminals to which the pole is connected.
        /// </summary>
        /// <remarks>
        /// Aggregation.
        /// </remarks>
        public TransformerEnd[] TransformerEnd
        {
            get => _transformerEnd;
        }
        // TODO: does constructor should take sequenceNumber? if it does, there's should be a validation
        /// <summary>
        /// Terminal constructor.
        /// </summary>
        /// <param name="conductingEquipment"><inheritdoc cref="ConductingEquipment" path="/summary/node()" /></param>
        public Terminal(ConductingEquipment conductingEquipment) : this(conductingEquipment, Guid.NewGuid()) { }
        // TODO: mrid??
        /// <summary>
        /// Terminal constructor.
        /// </summary>
        /// <param name="conductingEquipment"><inheritdoc cref="ConductingEquipment" path="/summary/node()" /></param>
        /// <param name="mRID"><inheritdoc cref="mRID" path="/summary/node()" /></param>
        public Terminal(ConductingEquipment conductingEquipment, Guid mRID) 
            : this(1, conductingEquipment, mRID) { }
        /// <summary>
        /// Terminal constructor.
        /// </summary>
        /// <param name="sequenceNumber"><inheritdoc cref="ACDCTerminal.sequenceNumber" path="/summary/node()" /></param>
        /// <param name="conductingEquipment"><inheritdoc cref="ConductingEquipment" path="/summary/node()" /></param>
        public Terminal(int sequenceNumber, ConductingEquipment conductingEquipment) 
            : this(sequenceNumber, conductingEquipment, Guid.NewGuid()) { }
        /// <summary>
        /// Terminal constructor.
        /// </summary>
        /// <param name="sequenceNumber"><inheritdoc cref="ACDCTerminal.sequenceNumber" path="/summary/node()" /></param>
        /// <param name="conductingEquipment"><inheritdoc cref="ConductingEquipment" path="/summary/node()" /></param>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Terminal(int sequenceNumber, ConductingEquipment conductingEquipment, Guid mRID) : base(mRID, sequenceNumber)
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

        public void AddToAuxiliaryEquipment(AuxiliaryEquipment auxiliaryEquipment)
        {
            if (!_auxiliaryEquipment.Contains(auxiliaryEquipment))
            {
                Array.Resize(ref _auxiliaryEquipment, _auxiliaryEquipment.Length + 1);
                _auxiliaryEquipment[_auxiliaryEquipment.Length - 1] = auxiliaryEquipment;

                //auxiliaryEquipment.Terminal = this;
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

                //auxiliaryEquipment.Terminal = null;
            }
        }

        public void AddToTransformerEnd(TransformerEnd transformerEnd)
        {
            if (!_transformerEnd.Contains(transformerEnd))
            {
                Array.Resize(ref _transformerEnd, _transformerEnd.Length + 1);
                _transformerEnd[_transformerEnd.Length - 1] = transformerEnd;

                //transformerEnd.Terminal = this;
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

                //transformerEnd.Terminal = null;
            }
        }
    }
}
