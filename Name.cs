using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Name
    {
        private IdentifiedObject _identifiedObject;

        public IdentifiedObject IdentifiedObject
        {
            get => _identifiedObject;
            set
            {
                if (value == null)
                {
                    throw new FormatException("Name must be associated with IdentifiedObject");
                }
                else
                {
                    _identifiedObject = value;
                }
            }
        }

        // TODO: changing nameType
        public NameType NameType { get; set; }
        
        public string name { get; set; }

        public Name(NameType nameType, string name, IdentifiedObject identifiedObject)
        {
            NameType = nameType;
            NameType.AddToNames(this);
            this.name = name;
            IdentifiedObject = identifiedObject;
        }
    }
}
