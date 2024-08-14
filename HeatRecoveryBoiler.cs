namespace CIM
{
    /// <summary>
    /// Heat recovery boiler.
    /// </summary>
    public class HeatRecoveryBoiler : FossilSteamSupply
    {
        private CombustionTurbine[] _combustionTurbine = [];

        /// <summary>
        /// Gas turbine of waste heat boiler.
        /// </summary>
        public CombustionTurbine[] CombustionTurbine
        {
            get => _combustionTurbine;
        }

        /// <summary>
        /// HeatRecoveryBoiler constructor.
        /// </summary>
        public HeatRecoveryBoiler() : base() { }
        /// <summary>
        /// HeatRecoveryBoiler constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public HeatRecoveryBoiler(Guid mRID) : base(mRID) { }

        public void AddToCombustionTurbine(CombustionTurbine combustionTurbine)
        {
            if (!_combustionTurbine.Contains(combustionTurbine))
            {
                Array.Resize(ref _combustionTurbine, _combustionTurbine.Length + 1);
                _combustionTurbine[_combustionTurbine.Length - 1] = combustionTurbine;

                //combustionTurbine.HeatRecoveryBoiler = this;
            }
        }

        public void RemoveFromCombustionTurbine(CombustionTurbine combustionTurbine)
        {
            if (_combustionTurbine.Contains(combustionTurbine))
            {
                CombustionTurbine[] tempArray = [];

                for (int i = 0; i < _combustionTurbine.Length; i++)
                {
                    if (_combustionTurbine[i].mRID != combustionTurbine.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _combustionTurbine[i];
                    }
                }

                _combustionTurbine = tempArray;

                //combustionTurbine.HeatRecoveryBoiler = null;
            }
        }
    }
}
