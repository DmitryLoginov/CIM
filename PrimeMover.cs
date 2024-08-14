namespace CIM
{
    /// <summary>
    /// Prime mover.
    /// </summary>
    public abstract class PrimeMover : PowerSystemResource
    {
        private AsynchronousMachine? _asynchronousMachine;
        private SynchronousMachine[] _synchronousMachines = [];

        // TODO: rf
        /// <summary>
        /// Asynchronous generator connected to the prime mover.
        /// </summary>
        public AsynchronousMachine? AsynchronousMachine
        {
            get => _asynchronousMachine;
            set
            {
                if (_asynchronousMachine != null)
                {
                    _asynchronousMachine = value;
                    _asynchronousMachine.PrimeMover = this;
                }
                else
                {
                    if (_asynchronousMachine != null)
                    {
                        _asynchronousMachine.PrimeMover = null;
                        _asynchronousMachine = null;
                    }
                }
            }
        }

        /// <summary>
        /// Synchronous generator connected to the prime mover.
        /// </summary>
        public SynchronousMachine[] SynchronousMachines
        {
            get => _synchronousMachines;
        }

        /// <summary>
        /// PrimeMover constructor.
        /// </summary>
        protected PrimeMover() : base() { }
        /// <summary>
        /// PrimeMover constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected PrimeMover(Guid mRID) : base(mRID) { }

        public void AddToSynchronousMachines(SynchronousMachine synchronousMachine)
        {
            if (!_synchronousMachines.Contains(synchronousMachine))
            {
                Array.Resize(ref _synchronousMachines, _synchronousMachines.Length + 1);
                _synchronousMachines[_synchronousMachines.Length - 1] = synchronousMachine;

                synchronousMachine.AddToPrimeMovers(this);
            }
        }

        public void RemoveFromSynchronousMachines(SynchronousMachine synchronousMachine)
        {
            if (_synchronousMachines.Contains(synchronousMachine))
            {
                SynchronousMachine[] tempArray = [];

                for (int i = 0; i < _synchronousMachines.Length; i++)
                {
                    // TODO: name and nameType
                    if (_synchronousMachines[i].mRID != synchronousMachine.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _synchronousMachines[i];
                    }
                }

                _synchronousMachines = tempArray;

                synchronousMachine.RemoveFromPrimeMovers(this);
            }
        }
    }
}
