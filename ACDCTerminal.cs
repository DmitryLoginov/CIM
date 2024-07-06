namespace CIM
{
    public abstract class ACDCTerminal : IdentifiedObject
    {
        private int _sequenceNumber;
        
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
        /// doubtful but okay?
        /// </summary>
        protected ACDCTerminal() { }
        protected ACDCTerminal(int sequenceNumber)
        {
            this.sequenceNumber = sequenceNumber;
        }
        protected ACDCTerminal(int sequenceNumber, Guid mRID) : base(mRID)
        {
            this.sequenceNumber = sequenceNumber;
        }
    }
}
