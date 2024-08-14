namespace CIM
{
    /// <summary>
    /// Synchronous machine.
    /// </summary>
    public class SynchronousMachine : RotatingMachine
    {
        private PrimeMover[] _primeMovers = [];

        /// <summary>
        /// Synchronous generator prime mover.
        /// </summary>
        public PrimeMover[] PrimeMovers
        {
            get => _primeMovers;
        }

        /// <summary>
        /// SynchronousMachine constructor.
        /// </summary>
        public SynchronousMachine() : base() { }
        /// <summary>
        /// SynchronousMachine constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public SynchronousMachine(Guid mRID) : base(mRID) { }

        public void AddToPrimeMovers(PrimeMover primeMover)
        {
            if (!_primeMovers.Contains(primeMover))
            {
                Array.Resize(ref _primeMovers, _primeMovers.Length + 1);
                _primeMovers[_primeMovers.Length - 1] = primeMover;

                primeMover.AddToSynchronousMachines(this);
            }
        }

        public void RemoveFromPrimeMovers(PrimeMover primeMover)
        {
            if (_primeMovers.Contains(primeMover))
            {
                PrimeMover[] tempArray = [];

                for (int i = 0; i < _primeMovers.Length; i++)
                {
                    if (_primeMovers[i].mRID != primeMover.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _primeMovers[i];
                    }
                }

                _primeMovers = tempArray;

                primeMover.RemoveFromSynchronousMachines(this);
            }
        }
    }
}
