namespace CIM
{
    /// <summary>
    /// Linear phase shifter.
    /// </summary>
    public class PhaseTapChangerLinear : PhaseTapChanger
    {
        /// <summary>
        /// Change in phase angle when changing the position of the adjusting tap by one step, deg.
        /// </summary>
        public double stepPhaseShiftingIncrement { get; set; }
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
