using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CIM
{
    public abstract class PowerSystemResource : IdentifiedObject
    {
        private Asset[] _assets = [];

        public AssetInfo AssetDataSheet { get; set; }
        public Asset[] Assets
        {
            get => _assets;
        }
        public PSRType PSRType { get; set; }

        protected PowerSystemResource() { }
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
                    // TODO: name and nameType
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
