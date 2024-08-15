namespace CIM
{
    /// <summary>
    /// Row of the table of the phase-shifting switch of the adjusting taps of the transformer winding.
    /// </summary>
    public class PhaseTapChangerTablePoint : TapChangerTablePoint
    {
        /// <summary>
        /// Angle difference, deg.
        /// </summary>
        public double angle { get; set; }
    }
}
