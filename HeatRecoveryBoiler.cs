using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class HeatRecoveryBoiler : FossilSteamSupply
    {
        private CombustionTurbine[] _combustionTurbines = [];

        public CombustionTurbine[] CombustionTurbines
        {
            get => _combustionTurbines;
        }
        
        public HeatRecoveryBoiler() { }
        public HeatRecoveryBoiler(Guid mRID) : base(mRID) { }

        public void AddToCombustionTurbines(CombustionTurbine combustionTurbine)
        {
            if (!_combustionTurbines.Contains(combustionTurbine))
            {
                Array.Resize(ref _combustionTurbines, _combustionTurbines.Length + 1);
                _combustionTurbines[_combustionTurbines.Length - 1] = combustionTurbine;

                combustionTurbine.HeatRecoveryBoiler = this;
            }
        }

        public void RemoveFromCombustionTurbines(CombustionTurbine combustionTurbine)
        {
            if (_combustionTurbines.Contains(combustionTurbine))
            {
                CombustionTurbine[] tempArray = [];

                for (int i = 0; i < _combustionTurbines.Length; i++)
                {
                    if (_combustionTurbines[i].mRID != combustionTurbine.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _combustionTurbines[i];
                    }
                }

                _combustionTurbines = tempArray;

                combustionTurbine.HeatRecoveryBoiler = null;
            }
        }
    }
}
