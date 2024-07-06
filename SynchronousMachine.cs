using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class SynchronousMachine : RotatingMachine
    {
        private PrimeMover[] _primeMovers = [];

        public PrimeMover[] PrimeMovers
        {
            get => _primeMovers;
        }
        
        public SynchronousMachine() { }
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
