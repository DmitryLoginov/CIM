namespace CIM
{
    /// <summary>
    /// Typed role of the organization in relation to other objects of the information model.
    /// </summary>
    public class OrganisationRole : IdentifiedObject
    {
        private IdentifiedObject[] _objects = [];
        private Organisation _organisation;

        // TODO: rf
        /// <summary>
        /// Information model objects associated with an organization's role.
        /// </summary>
        /// <remarks>
        /// The association is an extension of the standard model 
        /// and is used in practice to specify the roles of organizations 
        /// in relation to information model objects of various types, 
        /// and not just for models of material objects. 
        /// It is used in cases where the inclusion of models of material objects 
        /// in information exchange is impractical or they are missing.
        /// </remarks>
        public IdentifiedObject[] Objects
        {
            get => _objects;
        }
        /// <summary>
        /// Organization having a given role.
        /// </summary>
        public Organisation Organisation
        {
            get => _organisation;
            set
            {
                if (value != null)
                {
                    _organisation = value;
                    value.AddToRoles(this);
                }
                else
                {
                    // TODO: error: OrganisationRole without an Organisation
                    _organisation.RemoveFromRoles(this);
                    _organisation = null;
                }
            }
        }

        /// <summary>
        /// OrganisationRole constructor.
        /// </summary>
        public OrganisationRole() : base() { }
        /// <summary>
        /// OrganisationRole constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public OrganisationRole(Guid mRID) : base(mRID) { }
        // TODO: i dont like this
        /// <summary>
        /// OrganisationRole constructor.
        /// </summary>
        /// <param name="organisation"><inheritdoc cref="Organisation" path="/summary/node()" /></param>
        public OrganisationRole(Organisation organisation) : this(Guid.NewGuid(), organisation) { }
        /// <summary>
        /// OrganisationRole constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="organisation"><inheritdoc cref="Organisation" path="/summary/node()" /></param>
        public OrganisationRole(Guid mRID, Organisation organisation) : base(mRID)
        {
            Organisation = organisation;
        }

        public void AddToObjects(IdentifiedObject identifiedObject)
        {
#if DEBUG
            Console.WriteLine($"> in OrganisationRole.AddToObjects()");
#endif

            if (!_objects.Contains(identifiedObject))
            {
                Array.Resize(ref _objects, _objects.Length + 1);
                _objects[_objects.Length - 1] = identifiedObject;

                identifiedObject.AddToOrganisationRoles(this);
            }
        }

        public void RemoveFromObjects(IdentifiedObject identifiedObject)
        {
#if DEBUG
            Console.WriteLine($"> in OrganisationRole.RemoveFromObjects()");
#endif

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
