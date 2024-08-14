namespace CIM
{
    // TODO: global - look for associations 0..1, they can be already null when you're trying to assign null
    /// <summary>
    /// Identification class.
    /// </summary>
    /// <remarks>
    /// Provides identification and a set of names for inherited classes.
    /// </remarks>
    public abstract class IdentifiedObject
    {
        private Name[] _names = [];
        private OrganisationRole[] _organisationRoles = [];

        /// <summary>
        /// Name of the information model object.
        /// </summary>
        public string name { get; set; } = string.Empty;
        /// <summary>
        /// Additional name of the identified object.
        /// </summary>
        public string aliasName { get; set; } = string.Empty;
        /// <summary>
        /// Description of the information model object.
        /// </summary>
        public string description { get; set; } = string.Empty;
        /// <summary>
        /// Globally unique identifier of an information model object.
        /// </summary>
        public Guid mRID { get; }
        /// <summary>
        /// A set of typed names.
        /// </summary>
        public Name[] Names
        {
            get => _names;
        }
        // TODO: rf
        /// <summary>
        /// Roles of organizations in relation to the information model object.
        /// </summary>
        /// <remarks>
        /// The association is an extension of the standard model and is used in practice 
        /// to specify the roles of organizations in relation to information model objects of various types, 
        /// and not just for models of material objects. 
        /// It is used in cases where the inclusion of models of material objects in information exchange is impractical or they are missing.
        /// </remarks>
        public OrganisationRole[] OrganisationRoles
        {
            get => _organisationRoles;
        }

        /// <summary>
        /// IdentifiedObject constructor.
        /// </summary>
        protected IdentifiedObject()
        {
            mRID = Guid.NewGuid();
        }
        /// <summary>
        /// IdentifiedObject constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="mRID" path="/summary/node()" /></param>
        protected IdentifiedObject(Guid mRID)
        {
            if (mRID == Guid.Empty)
            {
                throw new ArgumentException("mRID was empty");
            }
            else
            {
                this.mRID = mRID;
            }
        }

        public void AddToNames(Name name)
        {
#if DEBUG
            Console.WriteLine($"> in IdentifiedObject.AddToNames()");
#endif

            if (!_names.Contains(name))
            {
                Array.Resize(ref _names, _names.Length + 1);
                _names[_names.Length - 1] = name;

                //name.IdentifiedObject = this;
            }
        }

        public void RemoveFromNames(Name name)
        {
#if DEBUG
            Console.WriteLine($"> in IdentifiedObject.RemoveFromNames()");
#endif

            if (_names.Contains(name))
            {
                Name[] tempArray = [];

                for (int i = 0; i < _names.Length; i++)
                {
                    //if (_names[i].name != name.name && _names[i].NameType != name.NameType)
                    if (_names[i] != name)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _names[i];
                    }
                }

                _names = tempArray;

                //name.IdentifiedObject = null;
            }
        }

        public void AddToOrganisationRoles(OrganisationRole organisationRole)
        {
#if DEBUG
            Console.WriteLine($"> in IdentifiedObject.AddToOrganisationRoles()");
#endif

            if (!_organisationRoles.Contains(organisationRole))
            {
                Array.Resize(ref _organisationRoles, _organisationRoles.Length + 1);
                _organisationRoles[_organisationRoles.Length - 1] = organisationRole;

                organisationRole.AddToObjects(this);
            }
        }

        public void RemoveFromOrganisationRoles(OrganisationRole organisationRole)
        {
#if DEBUG
            Console.WriteLine($"> in IdentifiedObject.RemoveFromOrganisationRoles()");
#endif

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
