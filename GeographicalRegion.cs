using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class GeographicalRegion : IdentifiedObject
    {
        private SubGeographicalRegion[] _regions = [];

        public SubGeographicalRegion[] Regions
        {
            get => _regions;
        }
        
        public GeographicalRegion() { }
        public GeographicalRegion(Guid mRID) : base(mRID) { }

        public void AddToRegions(SubGeographicalRegion region)
        {
            if (!_regions.Contains(region))
            {
                Array.Resize(ref _regions, _regions.Length + 1);
                _regions[_regions.Length - 1] = region;

                region.Region = this;
            }
        }

        public void RemoveFromRegions(SubGeographicalRegion region)
        {
            if (_regions.Contains(region))
            {
                SubGeographicalRegion[] tempArray = [];

                for (int i = 0; i < _regions.Length; i++)
                {
                    if (_regions[i].mRID != region.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _regions[i];
                    }
                }

                _regions = tempArray;

                region.Region = null;
            }
        }
    }
}
