namespace CIM
{
    /// <summary>
    /// Transformer electrical output.
    /// </summary>
    public abstract class TransformerEnd : IdentifiedObject
    {
        private BaseVoltage _baseVoltage;
        private PhaseTapChanger? _phaseTapChanger;
        private RatioTapChanger? _ratioTapChanger;
        private Terminal _terminal;
        
        public int endNumber { get; set; }
        public bool grounded { get; set; }
        /// <summary>
        /// Standard rated voltage of transformer output.
        /// </summary>
        public BaseVoltage BaseVoltage
        {
            get => _baseVoltage;
            set
            {
                if (value != null)
                {
                    _baseVoltage = value;
                    _baseVoltage.AddToTransformerEnd(this);
                }
                else
                {
                    // TODO: error: TransformerEnd without a BaseVoltage
                    _baseVoltage.RemoveFromTransformerEnd(this);
                    _baseVoltage = null;
                }
            }
        }
        /// <summary>
        /// Phase-shifting switch for adjustable taps of transformer winding.
        /// </summary>
        public PhaseTapChanger? PhaseTapChanger
        {
            get => _phaseTapChanger;
            set
            {
                if (value != null)
                {
                    _phaseTapChanger = value;
                    _phaseTapChanger.TransformerEnd = this;
                }
                else
                {
                    _phaseTapChanger.TransformerEnd = null;
                    _phaseTapChanger = null;
                }
            }
        }
        /// <summary>
        /// Switch of the transformer winding adjustment taps.
        /// </summary>
        public RatioTapChanger? RatioTapChanger
        {
            get => _ratioTapChanger;
            set
            {
                if (value != null)
                {
                    _ratioTapChanger = value;
                    _ratioTapChanger.TransformerEnd = this;
                }
                else
                {
                    _ratioTapChanger.TransformerEnd = null;
                    _ratioTapChanger = null;
                }
            }
        }
        /// <summary>
        /// The pole of a power transformer to which its terminals are connected
        /// </summary>
        public Terminal Terminal
        {
            get => _terminal;
            set
            {
                if (value != null)
                {
                    _terminal = value;
                    value.AddToTransformerEnd(this);
                }
                else
                {
                    // TODO: is this an error?
                    _terminal.RemoveFromTransformerEnd(this);
                    _terminal = null;
                }
            }
        }
        public TransformerMeshImpedance FromMeshImpedance { get; set; }
        public TransformerMeshImpedance ToMeshImpedance { get; set; }
        public TransformerStarImpedance StarImpedance { get; set; }

        /// <summary>
        /// TransformerEnd constructor.
        /// </summary>
        protected TransformerEnd() : base() { }
        /// <summary>
        /// TransformerEnd constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected TransformerEnd(Guid mRID) : base(mRID) { }
    }
}
