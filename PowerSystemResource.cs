namespace CIM
{
    /// <summary>
    /// Generalized energy system object.
    /// </summary>
    public abstract class PowerSystemResource : IdentifiedObject
    {
        private Asset[] _assets = [];
        private PSRType? _psrType;

        /// <summary>
        /// Property objects associated with the energy system object.
        /// </summary>
        public Asset[] Assets
        {
            get => _assets;
        }
        /// <summary>
        /// Additional classifier.
        /// </summary>
        public PSRType? PSRType
        {
            get => _psrType;
            set
            {
                if (value != null)
                {
                    _psrType = value;
                    value.AddToPowerSystemResources(this);
                }
                else
                {
                    if (_psrType != null)
                    {
                        _psrType.RemoveFromPowerSystemResources(this);
                        _psrType = null;
                    }
                }
            }
        }

        /// <summary>
        /// PowerSystemResource constructor.
        /// </summary>
        protected PowerSystemResource() : base() { }

        /// <summary>
        /// PowerSystemResource constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected PowerSystemResource(Guid mRID) : base(mRID) { }

        public void AddToAssets(Asset asset)
        {
            if (!_assets.Contains(asset))
            {
                Array.Resize(ref _assets, _assets.Length + 1);
                _assets[_assets.Length - 1] = asset;

                asset.AddToPowerSystemResource(this);
            }
        }

        public void RemoveFromAssets(Asset asset)
        {
            if (_assets.Contains(asset))
            {
                Asset[] tempArray = [];

                for (int i = 0; i < _assets.Length; i++)
                {
                    if (_assets[i].mRID != asset.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _assets[i];
                    }
                }

                _assets = tempArray;

                asset.RemoveFromPowerSystemResource(this);
            }
        }
    }
}
