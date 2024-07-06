using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class SteamTurbine : PrimeMover
    {
        private SteamSupply[] _steamSupplies = [];

        public SteamSupply[] SteamSupplies
        {
            get => _steamSupplies;
        }

        public SteamTurbine() { }
        public SteamTurbine(Guid mRID) : base(mRID) { }

        public void AddToSteamSupplies(SteamSupply steamSupply)
        {
            if (!_steamSupplies.Contains(steamSupply))
            {
                Array.Resize(ref _steamSupplies, _steamSupplies.Length + 1);
                _steamSupplies[_steamSupplies.Length - 1] = steamSupply;

                steamSupply.AddToSteamTurbines(this);
            }
        }

        public void RemoveFromSteamSupplies(SteamSupply steamSupply)
        {
            if (_steamSupplies.Contains(steamSupply))
            {
                SteamSupply[] tempArray = [];

                for (int i = 0; i < _steamSupplies.Length; i++)
                {
                    if (_steamSupplies[i].mRID != steamSupply.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _steamSupplies[i];
                    }
                }

                _steamSupplies = tempArray;

                steamSupply.RemoveFromSteamTurbines(this);
            }
        }
    }
}
