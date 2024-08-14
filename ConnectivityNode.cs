namespace CIM
{
    /// <summary>
    /// Connection node.
    /// </summary>
    public class ConnectivityNode : IdentifiedObject
    {
        private ConnectivityNodeContainer _connectivityNodeContainer;
        private Terminal[] _terminals = [];

        /// <summary>
        /// Container of connecting nodes.
        /// </summary>
        public ConnectivityNodeContainer ConnectivityNodeContainer
        {
            get => _connectivityNodeContainer;
            set
            {
                if (value != null)
                {
                    _connectivityNodeContainer = value;
                    value.AddToConnectivityNodes(this);
                }
                else
                {
                    // TODO: error: ConnectivityNode without a container
                    _connectivityNodeContainer.RemoveFromConnectivityNodes(this);
                    _connectivityNodeContainer = null;
                }
            }
        }

        /// <summary>
        /// United poles.
        /// </summary>
        public Terminal[] Terminals
        {
            get => _terminals;
        }

        /// <summary>
        /// ConnectivityNode constructor.
        /// </summary>
        public ConnectivityNode() : base() { }
        /// <summary>
        /// ConnectivityNode constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public ConnectivityNode(Guid mRID) : base(mRID) { }
        /// <summary>
        /// ConnectivityNode constructor.
        /// </summary>
        /// <param name="connectivityNodeContainer"></param>
        public ConnectivityNode(ConnectivityNodeContainer connectivityNodeContainer)
            : this(connectivityNodeContainer, Guid.NewGuid()) { }
        /// <summary>
        /// ConnectivityNode constructor.
        /// </summary>
        /// <param name="connectivityNodeContainer"><inheritdoc cref="ConnectivityNodeContainer" path="/summary/node()" /></param>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public ConnectivityNode(ConnectivityNodeContainer connectivityNodeContainer, Guid mRID) : base(mRID)
        {
            ConnectivityNodeContainer = connectivityNodeContainer;
        }

        public void AddToTerminals(Terminal terminal)
        {
            if (!_terminals.Contains(terminal))
            {
                Array.Resize(ref _terminals, _terminals.Length + 1);
                _terminals[_terminals.Length - 1] = terminal;

                //terminal.ConnectivityNode = this;
            }
        }

        public void RemoveFromTerminals(Terminal terminal)
        {
            if (_terminals.Contains(terminal))
            {
                Terminal[] tempArray = [];

                for (int i = 0; i < _terminals.Length; i++)
                {
                    if (_terminals[i].mRID != terminal.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _terminals[i];
                    }
                }

                _terminals = tempArray;

                //terminal.ConnectivityNode = null;
            }
        }
    }
}
