namespace CIM
{
    /// <summary>
    /// Federal District of the Russian Federation.
    /// </summary>
    public class GeographicalRegion : IdentifiedObject
    {
        private SubGeographicalRegion[] _regions = [];

        /// <summary>
        /// Subjects of the Russian Federation.
        /// </summary>
        public SubGeographicalRegion[] Regions
        {
            get => _regions;
        }

        /// <summary>
        /// GeographicalRegion constructor.
        /// </summary>
        public GeographicalRegion() : base() { }
        /// <summary>
        /// GeographicalRegion constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public GeographicalRegion(Guid mRID) : base(mRID) { }

        public void AddToRegions(SubGeographicalRegion region)
        {
            if (!_regions.Contains(region))
            {
                Array.Resize(ref _regions, _regions.Length + 1);
                _regions[_regions.Length - 1] = region;

                //region.Region = this;
            }
        }

        public void RemoveFromRegions(SubGeographicalRegion region)
        {
            if (_regions.Contains(region))
            {
                SubGeographicalRegion[] tempArray = [];

                for (int i = 0; i < _regions.Length; i++)
                {
                    if (_regions[i].mRID != region.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _regions[i];
                    }
                }

                _regions = tempArray;

                //region.Region = null;
            }
        }
    }
}
