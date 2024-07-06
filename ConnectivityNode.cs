using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class ConnectivityNode : IdentifiedObject
    {
        //private ConnectivityNodeContainer _connectivityNodeContainer;

        private Terminal[] _terminals;

        public ConnectivityNodeContainer ConnectivityNodeContainer { get; set; }
        //{
        //    get => _connectivityNodeContainer;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new FormatException("ConnectivityNode must be contained in ConnectivityNodeContainer");
        //        }
        //        else
        //        {
        //            _connectivityNodeContainer = value;
        //        }
        //    }
        //}

        public Terminal[] Terminals
        {
            get => _terminals;
        }

        public ConnectivityNode() { }
        public ConnectivityNode(Guid mRID) : base(mRID) { }
        public ConnectivityNode(ConnectivityNodeContainer connectivityNodeContainer)
        {
            ConnectivityNodeContainer = connectivityNodeContainer;
        }

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

                terminal.ConnectivityNode = this;
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

                // TODO: issue
                terminal.ConnectivityNode = null;
            }
        }
    }
}
