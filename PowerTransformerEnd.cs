namespace CIM
{
    /// <summary>
    /// Electrical terminal of power transformer.
    /// </summary>
    public class PowerTransformerEnd : TransformerEnd
    {
        private PowerTransformer _powerTransformer;
        
        public double b { get; set; }
        public WindingConnection connectionKind { get; set; }
        public double g { get; set; }
        public int phaseAngleClock { get; set; }
        public double r { get; set; }
        public double ratedS { get; set; }
        public double ratedU { get; set; }
        public double x { get; set; }
        /// <summary>
        /// Power transformer to which the terminal belongs.
        /// </summary>
        public PowerTransformer PowerTransformer
        {
            get => _powerTransformer;
            set
            {
                if (_powerTransformer != null)
                {
                    _powerTransformer = value;
                    _powerTransformer.AddToPowerTransformerEnd(this);
                }
                else
                {
                    if (_powerTransformer != null)
                    {
                        _powerTransformer.RemoveFromPowerTransformerEnd(this);
                        _powerTransformer = null;
                    }
                }
            }
        }
        public TransformerEndInfo TransformerEndInfo { get; set; }

        /// <summary>
        /// PowerTransformerEnd constructor.
        /// </summary>
        public PowerTransformerEnd() : base() { }
        /// <summary>
        /// PowerTransformerEnd constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public PowerTransformerEnd(Guid mRID) : base(mRID) { }
        /// <summary>
        /// PowerTransformerEnd constructor.
        /// </summary>
        /// <param name="powerTransformer"><inheritdoc cref="PowerTransformer" path="/summary/node()" /></param>
        public PowerTransformerEnd(PowerTransformer powerTransformer) 
            : this(Guid.NewGuid(), powerTransformer) { }
        /// <summary>
        /// PowerTransformerEnd constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="powerTransformer"><inheritdoc cref="PowerTransformer" path="/summary/node()" /></param>
        public PowerTransformerEnd(Guid mRID, PowerTransformer powerTransformer) : base(mRID)
        {
            PowerTransformer = powerTransformer;
        }
    }
}
