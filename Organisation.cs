using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class Organisation : IdentifiedObject
    {
        /// <summary>
        /// rf
        /// </summary>
        private Organisation[] _childOrganisations = [];
        private OrganisationRole[] _roles = [];

        /// <summary>
        /// rf
        /// </summary>
        public Organisation[] ChildOrganisations
        {
            get => _childOrganisations;
        }
        /// <summary>
        /// rf
        /// </summary>
        public Organisation ParentOrganisation { get; set; }
        public OrganisationRole[] Roles { get; set; }

        public Organisation() { }
        public Organisation(Guid mRID) : base(mRID) { }

        public void AddToChildOrganisations(Organisation childOrganisation)
        {
            if (!_childOrganisations.Contains(childOrganisation))
            {
                Array.Resize(ref _childOrganisations, _childOrganisations.Length + 1);
                _childOrganisations[_childOrganisations.Length - 1] = childOrganisation;

                childOrganisation.ParentOrganisation = this;
            }
        }

        public void RemoveFromChildOrganisations(Organisation childOrganisation)
        {
            if (_childOrganisations.Contains(childOrganisation))
            {
                Organisation[] tempArray = [];

                for (int i = 0; i < _childOrganisations.Length; i++)
                {
                    if (_childOrganisations[i].mRID != childOrganisation.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _childOrganisations[i];
                    }
                }

                _childOrganisations = tempArray;

                childOrganisation.ParentOrganisation = null;
            }
        }

        public void AddToRoles(OrganisationRole organisationRole)
        {
            if (!_roles.Contains(organisationRole))
            {
                Array.Resize(ref _roles, _roles.Length + 1);
                _roles[_roles.Length - 1] = organisationRole;

                organisationRole.Organisation = this;
            }
        }

        public void RemoveFromRoles(OrganisationRole organisationRole)
        {
            if (_roles.Contains(organisationRole))
            {
                OrganisationRole[] tempArray = [];

                for (int i = 0; i < _roles.Length; i++)
                {
                    if (_roles[i].mRID != organisationRole.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _roles[i];
                    }
                }

                _roles = tempArray;

                organisationRole.Organisation = null;
            }
        }
    }
}
