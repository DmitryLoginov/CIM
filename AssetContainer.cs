namespace CIM
{
    public class AssetContainer : Asset
    {
        private Asset[] _assets = [];
        
        public Asset[] Assets
        {
            get => _assets;
        }

        public AssetContainer() { }

        public AssetContainer(Guid mRID) : base(mRID) { }

        public void AddToAssets(Asset asset)
        {
            if (!_assets.Contains(asset))
            {
                Array.Resize(ref _assets, _assets.Length + 1);
                _assets[_assets.Length - 1] = asset;

                asset.AssetContainer = this;
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

                asset.AssetContainer = null;
            }
        }
    }
}
