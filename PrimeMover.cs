using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CIM
{
    /// <summary>
    /// rf
    /// </summary>
    public abstract class PrimeMover : PowerSystemResource
    {
        private SynchronousMachine[] _synchronousMachines = [];

        /// <summary>
        /// rf
        /// </summary>
        public AsynchronousMachine AsynchronousMachine { get; set; }

        public SynchronousMachine[] SynchronousMachines
        {
            get => _synchronousMachines;
        }

        protected PrimeMover() { }
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
