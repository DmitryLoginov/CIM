using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public abstract class SteamSupply : PowerSystemResource
    {
        private SteamTurbine[] _steamTurbines = [];

        public SteamTurbine[] SteamTurbines
        {
            get => _steamTurbines;
        }
        
        protected SteamSupply() { }
        protected SteamSupply(Guid mRID) : base(mRID) { }

        public void AddToSteamTurbines(SteamTurbine steamTurbine)
        {
            if (!_steamTurbines.Contains(steamTurbine))
            {
                Array.Resize(ref _steamTurbines, _steamTurbines.Length + 1);
                _steamTurbines[_steamTurbines.Length - 1] = steamTurbine;

                steamTurbine.AddToSteamSupplies(this);
            }
        }

        public void RemoveFromSteamTurbines(SteamTurbine steamTurbine)
        {
            if (_steamTurbines.Contains(steamTurbine))
            {
                SteamTurbine[] tempArray = [];

                for (int i = 0; i < _steamTurbines.Length; i++)
                {
                    if (_steamTurbines[i].mRID != steamTurbine.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _steamTurbines[i];
                    }
                }

                _steamTurbines = tempArray;

                steamTurbine.RemoveFromSteamSupplies(this);
            }
        }
    }
}
