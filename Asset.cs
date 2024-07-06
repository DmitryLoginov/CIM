namespace CIM
{
    public class Asset : IdentifiedObject
    {
        private AssetContainer _assetContainer;

        private PowerSystemResource[] _powerSystemResource = [];

        public PowerSystemResource[] PowerSystemResource
        {
            get => _powerSystemResource;
        }

        public AssetContainer AssetContainer
        {
            get => _assetContainer;
            set
            {
                _assetContainer = value;
                _assetContainer.AddToAssets(this);
            }
        }

        public Asset() { }

        public Asset(Guid mRID) : base(mRID) { }

        public void AddToPowerSystemResource(PowerSystemResource powerSystemResource)
        {
            if (!_powerSystemResource.Contains(powerSystemResource))
            {
                Array.Resize(ref _powerSystemResource, _powerSystemResource.Length + 1);
                _powerSystemResource[_powerSystemResource.Length - 1] = powerSystemResource;

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
                        tempArray[tempArray.Length - 1] = _powerSystemResource[i];
                    }
                }

                _powerSystemResource = tempArray;

                powerSystemResource.RemoveFromAssets(this);
            }
        }
    }
}
