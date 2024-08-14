namespace CIM
{
    /// <summary>
    /// Asynchronous machine.
    /// </summary>
    public class AsynchronousMachine : RotatingMachine
    {
        private PrimeMover? _primeMover;

        /// <summary>
        /// Asynchronous generator prime mover.
        /// </summary>
        /// <remarks>
        /// rf
        /// </remarks>
        public PrimeMover? PrimeMover
        {
            get => _primeMover;
            set
            {
                if (value != null)
                {
                    _primeMover = value;
                    value.AsynchronousMachine = this;
                }
                else
                {
                    _primeMover.AsynchronousMachine = null;
                    _primeMover = null;
                }
            }
        }

        /// <summary>
        /// AsynchronousMachine constructor.
        /// </summary>
        public AsynchronousMachine() : base() { }
        /// <summary>
        /// AsynchronousMachine constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public AsynchronousMachine(Guid mRID) : base(mRID) { }
    }
}
