using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIM
{
    public class SubGeographicalRegion : IdentifiedObject
    {
        private Line[] _lines = [];
        /// <summary>
        /// rf
        /// </summary>
        private Plant[] _plants = [];
        private Substation[] _substations = [];

        public Line[] Lines
        {
            get => _lines;
        }
        /// <summary>
        /// rf
        /// </summary>
        public Plant[] Plants
        {
            get => _plants;
        }
        public Substation[] Substations
        {
            get => _substations;
        }
        
        // TODO: add
        public GeographicalRegion Region { get; set; }
        
        public SubGeographicalRegion() { }
        public SubGeographicalRegion(Guid mRID) : base(mRID) { }

        public void AddToLines(Line line)
        {
            if (!_lines.Contains(line))
            {
                Array.Resize(ref _lines, _lines.Length + 1);
                _lines[_lines.Length - 1] = line;

                line.AddToRegion(this);
            }
        }

        public void RemoveFromLines(Line line)
        {
            if (_lines.Contains(line))
            {
                Line[] tempArray = [];

                for (int i = 0; i < _lines.Length; i++)
                {
                    if (_lines[i].mRID != line.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _lines[i];
                    }
                }

                _lines = tempArray;

                line.RemoveFromRegion(this);
            }
        }

        public void AddToPlants(Plant plant)
        {
            if (!_plants.Contains(plant))
            {
                Array.Resize(ref _plants, _plants.Length + 1);
                _plants[_plants.Length - 1] = plant;

                plant.Region = this;
            }
        }

        public void RemoveFromPlants(Plant plant)
        {
            if (_plants.Contains(plant))
            {
                Plant[] tempArray = [];

                for (int i = 0; i < _plants.Length; i++)
                {
                    if (_plants[i].mRID != plant.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _plants[i];
                    }
                }

                _plants = tempArray;

                plant.Region = null;
            }
        }

        public void AddToSubstations(Substation substation)
        {
            if (!_substations.Contains(substation))
            {
                Array.Resize(ref _substations, _substations.Length + 1);
                _substations[_substations.Length - 1] = substation;

                substation.Region = this;
            }
        }

        public void RemoveFromSubstationsv(Substation substation)
        {
            if (_substations.Contains(substation))
            {
                Substation[] tempArray = [];

                for (int i = 0; i < _substations.Length; i++)
                {
                    if (_substations[i].mRID != substation.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _substations[i];
                    }
                }

                _substations = tempArray;

                substation.Region = null;
            }
        }
    }
}
