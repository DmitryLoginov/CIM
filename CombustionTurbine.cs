namespace CIM
{
    /// <summary>
    /// Gas turbine.
    /// </summary>
    public class CombustionTurbine : PrimeMover
    {
        private HeatRecoveryBoiler? _heatRecoveryBoiler;
        
        /// <summary>
        /// Gas turbine waste heat boiler.
        /// </summary>
        public HeatRecoveryBoiler? HeatRecoveryBoiler
        {
            get => _heatRecoveryBoiler;
            set
            {
                // TODO: null
                if (value != null)
                {
                    _heatRecoveryBoiler = value;
                    value.AddToCombustionTurbine(this);
                }
                else
                {
                    _heatRecoveryBoiler.AddToCombustionTurbine(this);
                    _heatRecoveryBoiler = null;
                }
            }
        }

        /// <summary>
        /// CombustionTurbine constructor.
        /// </summary>
        public CombustionTurbine() : base() { }
        /// <summary>
        /// CombustionTurbine constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public CombustionTurbine(Guid mRID) : base(mRID) { }
    }
}
