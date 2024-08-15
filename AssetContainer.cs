namespace CIM
{
    /// <summary>
    /// A property object that may consist of other property objects.
    /// </summary>
    public class AssetContainer : Asset
    {
        private Asset[] _assets = [];

        /// <summary>
        /// Property objects that are part of the current property object.
        /// </summary>
        public Asset[] Assets
        {
            get => _assets;
        }

        /// <summary>
        /// AssetContainer constructor.
        /// </summary>
        public AssetContainer() : base() { }

        /// <summary>
        /// AssetContainer constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public AssetContainer(Guid mRID) : base(mRID) { }

        public void AddToAssets(Asset asset)
        {
            if (!_assets.Contains(asset))
            {
                Array.Resize(ref _assets, _assets.Length + 1);
                _assets[^1] = asset;

                //asset.AssetContainer = this;
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
                        tempArray[^1] = _assets[i];
                    }
                }

                _assets = tempArray;

                //asset.AssetContainer = null;
            }
        }
    }
}
