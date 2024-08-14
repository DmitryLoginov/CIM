namespace CIM
{
    /// <summary>
    /// Subject of Russian Federation.
    /// </summary>
    public class SubGeographicalRegion : IdentifiedObject
    {
        private GeographicalRegion _region;
        private Line[] _lines = [];
        private Plant[] _plants = [];
        private Substation[] _substations = [];

        /// <summary>
        /// Lines passing through the territory of a subject of the Russian Federation.
        /// </summary>
        public Line[] Lines
        {
            get => _lines;
        }
        // TODO: rf
        /// <summary>
        /// Power plants located on the territory of a subject of the Russian Federation.
        /// </summary>
        public Plant[] Plants
        {
            get => _plants;
        }
        /// <summary>
        /// Substations located on the territory of a subject of the Russian Federation.
        /// </summary>
        public Substation[] Substations
        {
            get => _substations;
        }
        /// <summary>
        /// A geographic region that unites the subjects of the Russian Federation.
        /// </summary>
        public GeographicalRegion Region
        {
            get => _region;
            set
            {
                if (_region != null)
                {
                    _region = value;
                    _region.AddToRegions(this);
                }
                else
                {
                    if (_region != null)
                    {
                        _region.RemoveFromRegions(this);
                        _region = null;
                    }
                }
            }
        }

        /// <summary>
        /// SubGeographicalRegion constructor.
        /// </summary>
        public SubGeographicalRegion() : base() { }
        /// <summary>
        /// SubGeographicalRegion constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
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

                //plant.Region = this;
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

                //plant.Region = null;
            }
        }

        public void AddToSubstations(Substation substation)
        {
            if (!_substations.Contains(substation))
            {
                Array.Resize(ref _substations, _substations.Length + 1);
                _substations[_substations.Length - 1] = substation;

                //substation.Region = this;
            }
        }

        public void RemoveFromSubstations(Substation substation)
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

                //substation.Region = null;
            }
        }
    }
}
