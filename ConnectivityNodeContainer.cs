namespace CIM
{
    /// <summary>
    /// Container of connecting nodes.
    /// </summary>
    public abstract class ConnectivityNodeContainer : PowerSystemResource
    {
        private ConnectivityNode[] _connectivityNodes = [];

        /// <summary>
        /// Connector nodes included in a connection node container.
        /// </summary>
        public ConnectivityNode[] ConnectivityNodes
        {
            get => _connectivityNodes;
        }

        /// <summary>
        /// ConnectivityNodeContainer constructor.
        /// </summary>
        protected ConnectivityNodeContainer() { }
        /// <summary>
        /// ConnectivityNodeContainer constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected ConnectivityNodeContainer(Guid mRID) : base(mRID) { }

        // TODO: naming
        public void AddToConnectivityNodes(ConnectivityNode connectivityNode)
        {
            if (!_connectivityNodes.Contains(connectivityNode))
            {
                Array.Resize(ref _connectivityNodes, _connectivityNodes.Length + 1);
                _connectivityNodes[_connectivityNodes.Length - 1] = connectivityNode;

                //connectivityNode.ConnectivityNodeContainer = this;
            }
        }

        public void RemoveFromConnectivityNodes(ConnectivityNode connectivityNode)
        {
            if (_connectivityNodes.Contains(connectivityNode))
            {
                ConnectivityNode[] tempArray = [];

                for (int i = 0; i < _connectivityNodes.Length; i++)
                {
                    if (_connectivityNodes[i].mRID != connectivityNode.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _connectivityNodes[i];
                    }
                }

                _connectivityNodes = tempArray;

                //connectivityNode.ConnectivityNodeContainer = null;
            }
        }
    }
}
