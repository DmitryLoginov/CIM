namespace CIM
{
    /// <summary>
    /// Power unit.
    /// </summary>
    public abstract class GeneratingUnit : Equipment
    {
        private RotatingMachine _rotatingMachine;

        /// <summary>
        /// Generators included in the power unit.
        /// </summary>
        public RotatingMachine RotatingMachine
        {
            get => _rotatingMachine;
            set
            {
                if (value != null)
                {
                    _rotatingMachine = value;
                    value.GeneratingUnit = this;
                }
                else
                {
                    if (_rotatingMachine is not null)
                    {
                        _rotatingMachine.GeneratingUnit = null;
                        _rotatingMachine = null;
                    }
                }
            }
        }

        /// <summary>
        /// GeneratingUnit constructor.
        /// </summary>
        protected GeneratingUnit() : base() { }
        /// <summary>
        /// GeneratingUnit constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected GeneratingUnit(Guid mRID) : base(mRID) { }
    }
}
