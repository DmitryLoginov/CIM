using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class ConnectivityNodeContainer : PowerSystemResource
    {
        private ConnectivityNode[] _connectivityNodes = [];

        public ConnectivityNode[] ConnectivityNodes
        {
            get => _connectivityNodes;
        }
        
        protected ConnectivityNodeContainer() { }

        protected ConnectivityNodeContainer(Guid mRID) : base(mRID) { }

        // TODO: naming
        public void AddToConnectivityNodes(ConnectivityNode connectivityNode)
        {
            if (!_connectivityNodes.Contains(connectivityNode))
            {
                Array.Resize(ref _connectivityNodes, _connectivityNodes.Length + 1);
                _connectivityNodes[_connectivityNodes.Length - 1] = connectivityNode;

                connectivityNode.ConnectivityNodeContainer = this;
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

                connectivityNode.ConnectivityNodeContainer = null;
            }
        }
    }
}
