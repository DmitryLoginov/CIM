namespace CIM
{
    /// <summary>
    /// Type of power system object.
    /// </summary>
    public class PSRType : IdentifiedObject
    {
        private PowerSystemResource[] _powerSystemResources = [];

        /// <summary>
        /// Energy objects with an additional classifier.
        /// </summary>
        public PowerSystemResource[] PowerSystemResources
        {
            get => _powerSystemResources;
        }
        
        /// <summary>
        /// PSRType constructor.
        /// </summary>
        public PSRType() : base() { }
        /// <summary>
        /// PSRType constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public PSRType(Guid mRID) : base(mRID) { }

        public void AddToPowerSystemResources(PowerSystemResource powerSystemResource)
        {
            if (!_powerSystemResources.Contains(powerSystemResource))
            {
                Array.Resize(ref _powerSystemResources, _powerSystemResources.Length + 1);
                _powerSystemResources[_powerSystemResources.Length - 1] = powerSystemResource;

                //powerSystemResource.PSRType = this;
            }
        }

        public void RemoveFromPowerSystemResources(PowerSystemResource powerSystemResource)
        {
            if (_powerSystemResources.Contains(powerSystemResource))
            {
                PowerSystemResource[] tempArray = [];

                for (int i = 0; i < _powerSystemResources.Length; i++)
                {
                    if (_powerSystemResources[i].mRID != powerSystemResource.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _powerSystemResources[i];
                    }
                }

                _powerSystemResources = tempArray;

                //powerSystemResource.PSRType = null;
            }
        }
    }
}
