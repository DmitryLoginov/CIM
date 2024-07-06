using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CIM
{
    public class Line : EquipmentContainer
    {
        private SubGeographicalRegion[] _region = [];

        public SubGeographicalRegion[] Region
        {
            get => _region;
        }
        
        public Line() { }
        public Line(Guid mRID) : base(mRID) { }

        public void AddToRegion(SubGeographicalRegion subGeographicalRegion)
        {
            if (!_region.Contains(subGeographicalRegion))
            {
                Array.Resize(ref _region, _region.Length + 1);
                _region[_region.Length - 1] = subGeographicalRegion;

                subGeographicalRegion.AddToLines(this);
            }
        }

        public void RemoveFromRegion(SubGeographicalRegion subGeographicalRegion)
        {
            if (_region.Contains(subGeographicalRegion))
            {
                SubGeographicalRegion[] tempArray = [];

                for (int i = 0; i < _region.Length; i++)
                {
                    if (_region[i].mRID != subGeographicalRegion.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _region[i];
                    }
                }

                _region = tempArray;

                subGeographicalRegion.RemoveFromLines(this);
            }
        }
    }
}
