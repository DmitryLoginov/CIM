namespace CIM
{
    /// <summary>
    /// Property object.
    /// </summary>
    public class Asset : IdentifiedObject
    {
        private AssetContainer? _assetContainer;
        private PowerSystemResource[] _powerSystemResource = [];

        /// <summary>
        /// Power system objects associated with a property object.
        /// </summary>
        public PowerSystemResource[] PowerSystemResource
        {
            get => _powerSystemResource;
        }

        /// <summary>
        /// A property object that includes a current property object.
        /// </summary>
        public AssetContainer? AssetContainer
        {
            get => _assetContainer;
            set
            {
                if (value != null)
                {
                    _assetContainer = value;
                    value.AddToAssets(this);
                }
                else
                {
                    if (_assetContainer != null)
                    {
                        _assetContainer.RemoveFromAssets(this);
                        _assetContainer = null;
                    }
                }
            }
        }

        /// <summary>
        /// Asset constructor.
        /// </summary>
        public Asset() : base() { }

        /// <summary>
        /// Asset constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Asset(Guid mRID) : base(mRID) { }

        public void AddToPowerSystemResource(PowerSystemResource powerSystemResource)
        {
            if (!_powerSystemResource.Contains(powerSystemResource))
            {
                Array.Resize(ref _powerSystemResource, _powerSystemResource.Length + 1);
                _powerSystemResource[^1] = powerSystemResource;

                powerSystemResource.AddToAssets(this);
            }
        }

        public void RemoveFromPowerSystemResource(PowerSystemResource powerSystemResource)
        {
            if (_powerSystemResource.Contains(powerSystemResource))
            {
                PowerSystemResource[] tempArray = [];

                for (int i = 0; i < _powerSystemResource.Length; i++)
                {
                    if (_powerSystemResource[i].mRID != powerSystemResource.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[^1] = _powerSystemResource[i];
                    }
                }

                _powerSystemResource = tempArray;

                powerSystemResource.RemoveFromAssets(this);
            }
        }
    }
}
