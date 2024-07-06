using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CIM
{
    public class Plant : EquipmentContainer
    {
        /// <summary>
        /// rf
        /// </summary>
        private Substation[] _substations = [];

        /// <summary>
        /// rf
        /// </summary>
        public SubGeographicalRegion Region { get; set; }
        /// <summary>
        /// rf
        /// </summary>
        public Substation[] Substations
        {
            get => _substations;
        }

        public Plant() { }
        public Plant(Guid mRID) : base(mRID) { }

        public void AddToSubstations(Substation substation)
        {
            if (!_substations.Contains(substation))
            {
                Array.Resize(ref _substations, _substations.Length + 1);
                _substations[_substations.Length - 1] = substation;

                substation.Plant = this;
            }
        }

        public void RemoveFromSubstations(Substation substation)
        {
            if (_substations.Contains(substation))
            {
                Substation[] tempArray = [];

                for (int i = 0; i < _substations.Length; i++)
                {
                    // TODO: name and nameType
                    if (_substations[i].mRID != substation.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _substations[i];
                    }
                }

                _substations = tempArray;

                substation.Plant = null;
            }
        }
    }
}
