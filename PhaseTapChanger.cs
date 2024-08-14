namespace CIM
{
    /// <summary>
    /// Phase-shifting switch for adjustable taps of transformer winding.
    /// </summary>
    public abstract class PhaseTapChanger : TapChanger
    {
        private TransformerEnd _transformerEnd;
        
        /// <summary>
        /// The output of the power transformer, to which the cross-regulated tap changer belongs.
        /// </summary>
        public TransformerEnd TransformerEnd
        {
            get => _transformerEnd;
            set
            {
                if (_transformerEnd != null)
                {
                    _transformerEnd = value;
                    _transformerEnd.PhaseTapChanger = this;
                }
                else
                {
                    if (_transformerEnd != null)
                    {
                        _transformerEnd.PhaseTapChanger = null;
                        _transformerEnd = null;
                    }
                }
            }
        }

        /// <summary>
        /// PhaseTapChanger constructor.
        /// </summary>
        protected PhaseTapChanger() : base() { }
        /// <summary>
        /// PhaseTapChanger constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected PhaseTapChanger(Guid mRID) : base(mRID) { }
        /// <summary>
        /// PhaseTapChanger constructor.
        /// </summary>
        /// <param name="transformerEnd"><inheritdoc cref="TransformerEnd" path="/summary/node()" /></param>
        protected PhaseTapChanger(TransformerEnd transformerEnd) : this(Guid.NewGuid(), transformerEnd) { }
        /// <summary>
        /// PhaseTapChanger constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="transformerEnd"><inheritdoc cref="TransformerEnd" path="/summary/node()" /></param>
        protected PhaseTapChanger(Guid mRID, TransformerEnd transformerEnd) : base(mRID)
        {
            TransformerEnd = transformerEnd;
        }
    }
}
