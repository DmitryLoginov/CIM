﻿namespace CIM
{
    /// <summary>
    /// Auxiliary equipment.
    /// </summary>
    public abstract class AuxiliaryEquipment : Equipment
    {
        private Terminal _terminal;

        /// <summary>
        /// Auxiliary equipment pole. 
        /// </summary>
        public Terminal Terminal
        {
            get => _terminal;
            set
            {
                if (value != null)
                {
                    _terminal = value;
                    value.AddToAuxiliaryEquipment(this);
                }
                else
                {
                    // TODO: error: AuxiliaryEquipment without a Terminal
                    if (_terminal != null)
                    {
                        _terminal.RemoveFromAuxiliaryEquipment(this);
                        _terminal = null;
                    }
                }
            }
        }

        /// <summary>
        /// AuxiliaryEquipment constructor.
        /// </summary>
        protected AuxiliaryEquipment() : base() { }
        /// <summary>
        /// AuxiliaryEquipment constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        protected AuxiliaryEquipment(Guid mRID) : base(mRID) { }
        /// <summary>
        /// AuxiliaryEquipment constructor.
        /// </summary>
        /// <param name="terminal"><inheritdoc cref="Terminal" path="/summary/node()" /></param>
        protected AuxiliaryEquipment(Terminal terminal) 
            : this(Guid.NewGuid(), terminal) { }
        /// <summary>
        /// AuxiliaryEquipment constructor.
        /// </summary>
        /// <param name="mRID"><inheritdoc cref="IdentifiedObject.mRID" path="/summary/node()" /></param>
        /// <param name="terminal"><inheritdoc cref="Terminal" path="/summary/node()" /></param>
        protected AuxiliaryEquipment(Guid mRID, Terminal terminal) : base(mRID)
        {
            Terminal = terminal;
        }
    }
}
