namespace CIM
{
    /// <summary>
    /// Name type.
    /// </summary>
    public class NameType
    {
        private Name[] _names = [];

        /// <summary>
        /// Name type.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Name of the specified type.
        /// </summary>
        public Name[] Names
        {
            get => _names;
        }

        /// <summary>
        /// NameType constructor.
        /// </summary>
        /// <param name="name"><inheritdoc cref="name" path="/summary/node()" /></param>
        public NameType(string name)
        {
            this.name = name;
        }

        public void AddToNames(Name name)
        {
#if DEBUG
            Console.WriteLine($"> in NameType.AddToNames()");
#endif

            if (!_names.Contains(name))
            {
                Array.Resize(ref _names, _names.Length + 1);
                _names[_names.Length - 1] = name;

                //name.NameType = this;
            }
        }

        public void RemoveFromNames(Name name)
        {
#if DEBUG
            Console.WriteLine($"> in NameType.RemoveFromNames()");
#endif

            if (_names.Contains(name))
            {
                Name[] tempArray = [];

                for (int i = 0; i < _names.Length; i++)
                {
                    if (_names[i].name != name.name && _names[i].NameType != name.NameType)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _names[i];
                    }
                }

                _names = tempArray;

                //name.NameType = null;
            }
        }
    }
}
