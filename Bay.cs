﻿namespace CIM
{
    /// <summary>
    /// Switchgear bay.
    /// </summary>
    /// <remarks>
    /// A class intended to group equipment, usually designating a bay of switchgear.
    /// </remarks>
    public class Bay : EquipmentContainer
    {
        private VoltageLevel _voltageLevel;

        /// <summary>
        /// The switchgear to which the connection belongs.
        /// </summary>
        public VoltageLevel VoltageLevel
        {
            get => _voltageLevel;
            set
            {
                if (value != null)
                {
                    _voltageLevel = value;
                    value.AddToBays(this);
                }
                else
                {
                    // TODO: error: Bay without a VoltageLevel
                    if (_voltageLevel != null)
                    {
                        _voltageLevel.RemoveFromBays(this);
                        _voltageLevel = null;
                    }
                }
            }
            /*get => _voltageLevel;
            set
            {
                // TODO: allow null
                if (value == null)
                {
                    throw new FormatException("Bay must be associated with VoltageLevel");
                }
                else
                {
                    _voltageLevel = value;
                }
            }*/
        }

        /// <summary>
        /// Bay constructor.
        /// </summary>
        public Bay() : base() { }
        /// <summary>
        /// Bay constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        public Bay(Guid mRID) : base(mRID) { }
        /// <summary>
        /// Bay constructor.
        /// </summary>
        /// <param name="voltageLevel"><inheritdoc cref="VoltageLevel" path="/summary/node()" /></param>
        public Bay(VoltageLevel voltageLevel) : this(Guid.NewGuid(), voltageLevel) { }
        /// <summary>
        /// Bay constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="voltageLevel"><inheritdoc cref="VoltageLevel" path="/summary/node()" /></param>
        public Bay(Guid mRID, VoltageLevel voltageLevel) : base(mRID)
        {
            VoltageLevel = voltageLevel;
        }
    }
}
