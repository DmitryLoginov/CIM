namespace CIM
{
    /// <summary>
    /// Power transformer.
    /// </summary>
    public class PowerTransformer : ConductingEquipment
    {
        private PowerTransformerEnd[] _powerTransformerEnd = [];
        
        /// <summary>
        /// 
        /// </summary>
        public string vectorGroup { get; set; }
        /// <summary>
        /// Electrical terminals of the power transformer.
        /// </summary>
        public PowerTransformerEnd[] PowerTransformerEnd
        {
            get => _powerTransformerEnd;
        }

        /// <summary>
        /// PowerTransformer constructor.
        /// </summary>
        public PowerTransformer() : base() { }
        /// <summary>
        /// PowerTransformer constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public PowerTransformer(Guid mRID) : base(mRID) { }

        public void AddToPowerTransformerEnd(PowerTransformerEnd powerTransformerEnd)
        {
            if (!_powerTransformerEnd.Contains(powerTransformerEnd))
            {
                Array.Resize(ref _powerTransformerEnd, _powerTransformerEnd.Length + 1);
                _powerTransformerEnd[_powerTransformerEnd.Length - 1] = powerTransformerEnd;

                //powerTransformerEnd.PowerTransformer = this;
            }
        }

        public void RemoveFromPowerTransformerEnd(PowerTransformerEnd powerTransformerEnd)
        {
            if (_powerTransformerEnd.Contains(powerTransformerEnd))
            {
                PowerTransformerEnd[] tempArray = [];

                for (int i = 0; i < _powerTransformerEnd.Length; i++)
                {
                    // TODO: name and nameType
                    if (_powerTransformerEnd[i].mRID != powerTransformerEnd.mRID)
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = _powerTransformerEnd[i];
                    }
                }

                _powerTransformerEnd = tempArray;

                //powerTransformerEnd.PowerTransformer = null;
            }
        }
    }
}
