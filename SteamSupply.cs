namespace CIM
{
    /// <summary>
    /// Boiler.
    /// </summary>
    public abstract class SteamSupply : PowerSystemResource
    {
        private SteamTurbine[] _steamTurbines = [];

        /// <summary>
        /// Steam turbines supplied by a boiler.
        /// </summary>
        public SteamTurbine[] SteamTurbines
        {
            get => _steamTurbines;
        }

        /// <summary>
        /// SteamSupply constructor.
        /// </summary>
        protected SteamSupply() : base() { }
        /// <summary>
        /// SteamSupply constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected SteamSupply(Guid mRID) : base(mRID) { }

        public void AddToSteamTurbines(SteamTurbine steamTurbine)
        {
            if (!_steamTurbines.Contains(steamTurbine))
            {
                Array.Resize(ref _steamTurbines, _steamTurbines.Length + 1);
                _steamTurbines[_steamTurbines.Length - 1] = steamTurbine;

                steamTurbine.AddToSteamSupplies(this);
            }
        }

        public void RemoveFromSteamTurbines(SteamTurbine steamTurbine)
        {
            if (_steamTurbines.Contains(steamTurbine))
            {
                SteamTurbine[] tempArray = [];

                for (int i = 0; i < _steamTurbines.Length; i++)
                {
                    if (_steamTurbines[i].mRID != steamTurbine.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _steamTurbines[i];
                    }
                }

                _steamTurbines = tempArray;

                steamTurbine.RemoveFromSteamSupplies(this);
            }
        }
    }
}
