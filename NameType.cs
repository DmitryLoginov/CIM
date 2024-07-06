using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class NameType
    {
        private Name[] _names = [];

        public string name { get; set; }

        public Name[] Names
        {
            get => _names;
        }

        public NameType(string name)
        {
            this.name = name;
        }

        // TODO: chng
        public void AddToNames(Name name)
        {
            if (!_names.Contains(name))
            {
                Array.Resize(ref _names, _names.Length + 1);
                _names[_names.Length - 1] = name;

                //name.EquipmentContainer = this;
            }
        }

        public void RemoveFromNames(Name name)
        {
            if (_names.Contains(name))
            {
                Name[] tempArray = [];

                for (int i = 0; i < _names.Length; i++)
                {
                    // TODO: name and nameType
                    if (_names[i].mRID != name.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _names[i];
                    }
                }

                _names = tempArray;

                name.NameType = null;
            }
        }
    }
}
