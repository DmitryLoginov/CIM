namespace CIM
{
    /// <summary>
    /// Rotating machine.
    /// </summary>
    public abstract class RotatingMachine : RegulatingCondEq
    {
        private GeneratingUnit _generatingUnit;

        /// <summary>
        /// The power unit to which the generator belongs.
        /// </summary>
        /// <remarks>
        /// Aggregation.
        /// </remarks>
        public GeneratingUnit GeneratingUnit
        {
            get => _generatingUnit;
            set
            {
                if (_generatingUnit != null)
                {
                    _generatingUnit = value;
                    _generatingUnit.RotatingMachine = this;
                }
                else
                {
                    if (_generatingUnit != null)
                    {
                        _generatingUnit.RotatingMachine = null;
                        _generatingUnit = null;
                    }
                }
            }
        }

        /// <summary>
        /// RotatingMachine constructor.
        /// </summary>
        protected RotatingMachine() : base() { }
        /// <summary>
        /// RotatingMachine constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected RotatingMachine(Guid mRID) : base(mRID) { }
    }
}
