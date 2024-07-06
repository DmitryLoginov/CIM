using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CIM
{
    public class PSRType : IdentifiedObject
    {
        private PowerSystemResource[] _powerSystemResources = [];

        public PowerSystemResource[] PowerSystemResources
        {
            get => _powerSystemResources;
        }
        
        public PSRType() { }
        public PSRType(Guid mRID) : base(mRID) { }

        public void AddToPowerSystemResources(PowerSystemResource powerSystemResource)
        {
            if (!_powerSystemResources.Contains(powerSystemResource))
            {
                Array.Resize(ref _powerSystemResources, _powerSystemResources.Length + 1);
                _powerSystemResources[_powerSystemResources.Length - 1] = powerSystemResource;

                powerSystemResource.PSRType = this;
            }
        }

        public void RemoveFromPowerSystemResources(PowerSystemResource powerSystemResource)
        {
            if (_powerSystemResources.Contains(powerSystemResource))
            {
                PowerSystemResource[] tempArray = [];

                for (int i = 0; i < _powerSystemResources.Length; i++)
                {
                    // TODO: name and nameType
                    if (_powerSystemResources[i].mRID != powerSystemResource.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _powerSystemResources[i];
                    }
                }

                _powerSystemResources = tempArray;

                powerSystemResource.PSRType = null;
            }
        }
    }
}
