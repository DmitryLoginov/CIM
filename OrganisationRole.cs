using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class OrganisationRole : IdentifiedObject
    {
        /// <summary>
        /// rf
        /// </summary>
        private IdentifiedObject[] _objects;

        /// <summary>
        /// rf
        /// </summary>
        public IdentifiedObject[] Objects
        {
            get => _objects;
        }
        public Organisation Organisation { get; set; }
        
        public OrganisationRole() { }
        public OrganisationRole(Guid mRID) : base(mRID) { }
        public OrganisationRole(Organisation organisation)
        {
            Organisation = organisation;
        }
        public OrganisationRole(Guid mRID, Organisation organisation) : base(mRID)
        {
            Organisation = organisation;
        }

        public void AddToObjects(IdentifiedObject identifiedObject)
        {
            if (!_objects.Contains(identifiedObject))
            {
                Array.Resize(ref _objects, _objects.Length + 1);
                _objects[_objects.Length - 1] = identifiedObject;

                identifiedObject.AddToOrganisationRoles(this);
            }
        }

        public void RemoveFromObjects(IdentifiedObject identifiedObject)
        {
            if (_objects.Contains(identifiedObject))
            {
                IdentifiedObject[] tempArray = [];

                for (int i = 0; i < _objects.Length; i++)
                {
                    if (_objects[i].mRID != identifiedObject.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _objects[i];
                    }
                }

                _objects = tempArray;

                identifiedObject.RemoveFromOrganisationRoles(this);
            }
        }
    }
}
