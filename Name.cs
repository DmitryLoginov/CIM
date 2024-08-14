namespace CIM
{
    /// <summary>
    /// Typed additional name.
    /// </summary>
    public class Name
    {
        private IdentifiedObject _identifiedObject;
        private NameType _nameType;
        
        /// <summary>
        /// An object that has a typed name.
        /// </summary>
        public IdentifiedObject IdentifiedObject
        {
            get => _identifiedObject;
            set
            {
                if (value != null)
                {
                    _identifiedObject = value;
                    value.AddToNames(this);
                }
                else
                {
                    // TODO: error: Name without an IdentifiedObject
                    _identifiedObject.RemoveFromNames(this);
                    _identifiedObject = null;
                }
            }
        }

        /// <summary>
        /// Name type.
        /// </summary>
        public NameType NameType
        {
            get => _nameType;
            set
            {
                if (value != null)
                {
                    _nameType = value;
                    value.AddToNames(this);
                }
                else
                {
                    // TODO: error: Name without a NameType
                    _nameType.RemoveFromNames(this);
                    _nameType = null;
                }
            }
        }

        /// <summary>
        /// Typed additional name of an information model object.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Name constructor.
        /// </summary>
        /// <param name="nameType"><inheritdoc cref="NameType" path="/summary/node()" /></param>
        /// <param name="name"><inheritdoc cref="name" path="/summary/node()" /></param>
        /// <param name="identifiedObject"><inheritdoc cref="IdentifiedObject" path="/summary/node()" /></param>
        public Name(NameType nameType, string name, IdentifiedObject identifiedObject)
        {
            NameType = nameType;
            //NameType.AddToNames(this);

            this.name = name;

            IdentifiedObject = identifiedObject;
            //identifiedObject.AddToNames(this);
        }
    }
}
