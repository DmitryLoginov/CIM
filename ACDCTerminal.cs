namespace CIM
{
    /// <summary>
    /// DC and AC pole.
    /// </summary>
    public abstract class ACDCTerminal : IdentifiedObject
    {
        private int _sequenceNumber;

        /// <summary>
        /// Serial number of the pole of electrically conductive equipment.
        /// </summary>
        public int sequenceNumber
        {
            get => _sequenceNumber;
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("sequenceNumber must be greater than zero");
                }
                else
                {
                    _sequenceNumber = value;
                }
            }
        }

        /// <summary>
        /// ACDCTerminal constructor.
        /// </summary>
        protected ACDCTerminal()
        {
            sequenceNumber = 1;
        }
        /// <summary>
        /// ACDCTerminal constructor.
        /// </summary>
        /// <param name="sequenceNumber"><inheritdoc cref="sequenceNumber" path="/summary/node()" /></param>
        protected ACDCTerminal(int sequenceNumber) : this(Guid.NewGuid(), sequenceNumber) { }
        /// <summary>
        /// ACDCTerminal constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="sequenceNumber"><inheritdoc cref="sequenceNumber" path="/summary/node()" /></param>
        protected ACDCTerminal(Guid mRID, int sequenceNumber) : base(mRID)
        {
            this.sequenceNumber = sequenceNumber;
        }
    }
}
