namespace CIM
{
    /// <summary>
    /// Nonlinear phase-shifting switch of transformer winding control taps.
    /// </summary>
    public abstract class PhaseTapChangerNonLinear : PhaseTapChanger
    {
        /// <summary>
        /// Voltage step when switching to an adjacent branch, as a percentage 
        /// of the nominal voltage of the power transformer output, %.
        /// </summary>
        public double voltageStepIncrement { get; set; }
        /// <summary>
        /// Maximum inductive reactance of the star beam, Ohm.
        /// </summary>
        /// <remarks>
        /// The dependence of the value on the number of the control branch is U-shaped. 
        /// The value specified by this attribute is typical for the two extreme branches: the upper and lower ones.
        /// </remarks>
        public double xMax { get; set; }
        /// <summary>
        /// Minimum inductive reactance of the star beam, Ohm.
        /// </summary>
        /// <remarks>
        /// The dependence of the value on the number of the control branch is U-shaped. 
        /// The value specified by this attribute is typical for the two extreme branches: the upper and lower ones.
        /// </remarks>
        public double xMin { get; set; }
    }
}
