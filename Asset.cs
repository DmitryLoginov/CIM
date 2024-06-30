using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Asset : IdentifiedObject
    {
        private PowerSystemResource[] _powerSystemResource = [];

        public PowerSystemResource[] PowerSystemResource
        {
            get => _powerSystemResource;
        }

        public AssetContainer AssetContainer { get; set; }

        public void AddToPowerSystemResource(PowerSystemResource powerSystemResource)
        {
            if (!_powerSystemResource.Contains(powerSystemResource))
            {
                Array.Resize(ref _powerSystemResource, PowerSystemResource.Length + 1);
                _powerSystemResource[_powerSystemResource.Length - 1] = powerSystemResource;
                // psr add asset logics
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

                // psr removal logic
            }
        }
    }
}
