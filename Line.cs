namespace CIM
{
    /// <summary>
    /// Power transmission line.
    /// </summary>
    public class Line : EquipmentContainer
    {
        private SubGeographicalRegion[] _region = [];

        /// <summary>
        /// Subjects of the Russian Federation through whose territory the power transmission line passes.
        /// </summary>
        public SubGeographicalRegion[] Region
        {
            get => _region;
        }
        
        /// <summary>
        /// Line constructor.
        /// </summary>
        public Line() : base() { }
        /// <summary>
        /// Line constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Line(Guid mRID) : base(mRID) { }

        public void AddToRegion(SubGeographicalRegion subGeographicalRegion)
        {
            if (!_region.Contains(subGeographicalRegion))
            {
                Array.Resize(ref _region, _region.Length + 1);
                _region[_region.Length - 1] = subGeographicalRegion;

                subGeographicalRegion.AddToLines(this);
            }
        }

        public void RemoveFromRegion(SubGeographicalRegion subGeographicalRegion)
        {
            if (_region.Contains(subGeographicalRegion))
            {
                SubGeographicalRegion[] tempArray = [];

                for (int i = 0; i < _region.Length; i++)
                {
                    if (_region[i].mRID != subGeographicalRegion.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _region[i];
                    }
                }

                _region = tempArray;

                subGeographicalRegion.RemoveFromLines(this);
            }
        }
    }
}
