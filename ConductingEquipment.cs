namespace CIM
{
    /// <summary>
    /// Electrically conductive equipment.
    /// </summary>
    public abstract class ConductingEquipment : Equipment
    {
        private BaseVoltage _baseVoltage;
        private Terminal[] _terminals = [];
        //protected readonly int _numberOfPoles;

        /// <summary>
        /// Standard rated voltage of electrically conductive equipment.
        /// </summary>
        public BaseVoltage BaseVoltage
        {
            get => _baseVoltage;
            set
            {
                if (value != null)
                {
                    _baseVoltage = value;
                    _baseVoltage.AddToConductingEquipment(this);
                }
                else
                {
                    // TODO: error: ConductingEquipment without a BaseVoltage
                    _baseVoltage.RemoveFromConductingEquipment(this);
                    _baseVoltage = null;
                }
            }
        }

        /// <summary>
        /// Poles of electrically conductive equipment.
        /// </summary>
        public Terminal[] Terminals
        {
            get => _terminals;
        }

        /// <summary>
        /// ConductingEquipment constructor.
        /// </summary>
        protected ConductingEquipment() : base() { }

        /// <summary>
        /// ConductingEquipment constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected ConductingEquipment(Guid mRID) : base(mRID) { }

        /// <summary>
        /// ConductingEquipment constructor.
        /// </summary>
        /// <param name="numberOfTerminals">Number of terminals for specified type of ConductingEquipment.</param>
        protected ConductingEquipment(int numberOfTerminals) 
            : this(numberOfTerminals, Guid.NewGuid()) { }

        /// <summary>
        /// ConductingEquipment constructor.
        /// </summary>
        /// <param name="numberOfTerminals">Number of terminals for specified type of ConductingEquipment.</param>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <exception cref="ArgumentException"><paramref name="numberOfTerminals"/> equals to zero.</exception>
        protected ConductingEquipment(int numberOfTerminals, Guid mRID) : base(mRID)
        {
            if (numberOfTerminals == 0)
            {
                throw new ArgumentException("ConductingEquipment must have one or more terminals");
            }
            else
            {
                for (int i = 0; i <= numberOfTerminals; i++)
                {
                    var terminal = new Terminal(this);

                    Array.Resize(ref _terminals, _terminals.Length + 1);
                    _terminals[_terminals.Length - 1] = terminal;
                }
            }
        }

        public void AddToTerminals(Terminal terminal)
        {
            if (!_terminals.Contains(terminal))
            {
                Array.Resize(ref _terminals, _terminals.Length + 1);
                _terminals[_terminals.Length - 1] = terminal;

                //childOrganisation.ParentOrganisation = this;
            }
        }

        public void RemoveFromTerminals(Terminal terminal)
        {
            if (_terminals.Contains(terminal))
            {
                Terminal[] tempArray = [];

                for (int i = 0; i < _terminals.Length; i++)
                {
                    if (_terminals[i].mRID != terminal.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _terminals[i];
                    }
                }

                _terminals = tempArray;

                //childOrganisation.ParentOrganisation = null;
            }
        }
    }
}
