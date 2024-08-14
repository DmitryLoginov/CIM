namespace CIM
{
    /// <summary>
    /// Steam turbine.
    /// </summary>
    public class SteamTurbine : PrimeMover
    {
        private SteamSupply[] _steamSupplies = [];

        /// <summary>
        /// Boilers supplying a steam turbine.
        /// </summary>
        public SteamSupply[] SteamSupplies
        {
            get => _steamSupplies;
        }

        /// <summary>
        /// SteamTurbine constructor.
        /// </summary>
        public SteamTurbine() : base() { }
        /// <summary>
        /// SteamTurbine constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public SteamTurbine(Guid mRID) : base(mRID) { }

        public void AddToSteamSupplies(SteamSupply steamSupply)
        {
            if (!_steamSupplies.Contains(steamSupply))
            {
                Array.Resize(ref _steamSupplies, _steamSupplies.Length + 1);
                _steamSupplies[_steamSupplies.Length - 1] = steamSupply;

                steamSupply.AddToSteamTurbines(this);
            }
        }

        public void RemoveFromSteamSupplies(SteamSupply steamSupply)
        {
            if (_steamSupplies.Contains(steamSupply))
            {
                SteamSupply[] tempArray = [];

                for (int i = 0; i < _steamSupplies.Length; i++)
                {
                    if (_steamSupplies[i].mRID != steamSupply.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _steamSupplies[i];
                    }
                }

                _steamSupplies = tempArray;

                steamSupply.RemoveFromSteamTurbines(this);
            }
        }
    }
}
