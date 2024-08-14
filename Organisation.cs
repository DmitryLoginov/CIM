namespace CIM
{
    /// <summary>
    /// Organization.
    /// </summary>
    public class Organisation : IdentifiedObject
    {
        private Organisation[] _childOrganisations = [];
        private OrganisationRole[] _roles = [];
        private Organisation? _parentOrganisation;

        // TODO: rf
        /// <summary>
        /// Subsidiaries and dependent organizations, branches.
        /// </summary>
        public Organisation[] ChildOrganisations
        {
            get => _childOrganisations;
        }
        // TODO: rf
        /// <summary>
        /// Parent organization, branch.
        /// </summary>
        public Organisation? ParentOrganisation
        {
            get => _parentOrganisation;
            set
            {
                if (value != null)
                {
                    _parentOrganisation = value;
                    value.AddToChildOrganisations(this);
                }
                else
                {
                    _parentOrganisation.RemoveFromChildOrganisations(this);
                    _parentOrganisation = null;
                }
            }
        }
        /// <summary>
        /// Roles performed by the organization.
        /// </summary>
        public OrganisationRole[] Roles
        {
            get => _roles;
        }

        /// <summary>
        /// Organisation constructor.
        /// </summary>
        public Organisation() : base() { }
        /// <summary>
        /// Organisation constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Organisation(Guid mRID) : base(mRID) { }

        public void AddToChildOrganisations(Organisation childOrganisation)
        {
            if (!_childOrganisations.Contains(childOrganisation))
            {
                Array.Resize(ref _childOrganisations, _childOrganisations.Length + 1);
                _childOrganisations[_childOrganisations.Length - 1] = childOrganisation;

                //childOrganisation.ParentOrganisation = this;
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

                //childOrganisation.ParentOrganisation = null;
            }
        }

        public void AddToRoles(OrganisationRole organisationRole)
        {
            if (!_roles.Contains(organisationRole))
            {
                Array.Resize(ref _roles, _roles.Length + 1);
                _roles[_roles.Length - 1] = organisationRole;

                //organisationRole.Organisation = this;
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

                //organisationRole.Organisation = null;
            }
        }
    }
}
