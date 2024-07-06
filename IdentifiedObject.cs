using System.Linq;

namespace CIM
{
    public abstract class IdentifiedObject
    {
        private Name[] _names = [];
        private OrganisationRole[] _organisationRoles = [];
        
        public string name { get; set; } = string.Empty;
        public string aliasName { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public Guid mRID { get; set; }
        public Name[] Names
        {
            get => _names;
        }
        /// <summary>
        /// rf
        /// </summary>
        public OrganisationRole[] OrganisationRoles
        {
            get => _organisationRoles;
        }

        protected IdentifiedObject()
        {
            mRID = new Guid();
        }
        protected IdentifiedObject(Guid mRID)
        {
            this.mRID = mRID;
        }

        public void AddToNames(Name name)
        {
            if (!_names.Contains(name))
            {
                Array.Resize(ref _names, _names.Length + 1);
                _names[_names.Length - 1] = name;

                name.EquipmentContainer = this;
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

                name.EquipmentContainer = null;
            }
        }

        public void AddToOrganisationRoles(OrganisationRole organisationRole)
        {
            if (!_organisationRoles.Contains(organisationRole))
            {
                Array.Resize(ref _organisationRoles, _organisationRoles.Length + 1);
                _organisationRoles[_organisationRoles.Length - 1] = organisationRole;

                organisationRole.AddToObjects(this);
            }
        }

        public void RemoveFromOrganisationRoles(OrganisationRole organisationRole)
        {
            if (_organisationRoles.Contains(organisationRole))
            {
                OrganisationRole[] tempArray = [];

                for (int i = 0; i < _organisationRoles.Length; i++)
                {
                    if (_organisationRoles[i].mRID != organisationRole.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _organisationRoles[i];
                    }
                }

                _organisationRoles = tempArray;

                organisationRole.RemoveFromObjects(this);
            }
        }
    }
}
