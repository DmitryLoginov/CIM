namespace CIM
{
    /// <summary>
    /// Transformation ratio regulator.
    /// </summary>
    public class RatioTapChanger : TapChanger
    {
        private TransformerEnd _transformerEnd;

        /// <summary>
        /// The output of the power transformer, to which the control tap switch with longitudinal regulation belongs.
        /// </summary>
        public TransformerEnd TransformerEnd
        {
            get => _transformerEnd;
            set
            {
                if (_transformerEnd != null)
                {
                    _transformerEnd = value;
                    _transformerEnd.RatioTapChanger = this;
                }
                else
                {
                    if (_transformerEnd != null)
                    {
                        _transformerEnd.RatioTapChanger = null;
                        _transformerEnd = null;
                    }
                }
            }
        }

        /// <summary>
        /// RatioTapChanger constructor.
        /// </summary>
        public RatioTapChanger() { }
        /// <summary>
        /// RatioTapChanger constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public RatioTapChanger(Guid mRID) : base(mRID) { }
        /// <summary>
        /// RatioTapChanger constructor.
        /// </summary>
        /// <param name="transformerEnd"><inheritdoc cref="TransformerEnd" path="/summary/node()" /></param>
        public RatioTapChanger(TransformerEnd transformerEnd) 
            : this(Guid.NewGuid(), transformerEnd) { }
        /// <summary>
        /// RatioTapChanger constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="transformerEnd"><inheritdoc cref="TransformerEnd" path="/summary/node()" /></param>
        public RatioTapChanger(Guid mRID, TransformerEnd transformerEnd) : base(mRID)
        {
            TransformerEnd = transformerEnd;
        }
    }
}
