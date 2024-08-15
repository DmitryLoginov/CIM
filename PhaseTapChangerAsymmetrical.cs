namespace CIM
{
    /// <summary>
    /// Asymmetrical phase shifter.
    /// </summary>
    /// <remarks>
    /// Asymmetrical phase shifter, changing the voltage of the initial output. 
    /// The phase of the changed transformation ratio depends on both the module and the phase 
    /// of the voltage boost (measured in relation to the voltage of the initial pole).
    /// </remarks>
    public class PhaseTapChangerAsymmetrical : PhaseTapChangerNonLinear
    {
        /// <summary>
        /// The angle at which the voltage booster module leads the voltage 
        /// of the output to which the switch is connected, deg.
        /// </summary>
        /// <remarks>
        /// Transverse (asymmetrical) regulation is set to 90 degrees.
        /// </remarks>
        public double WindingConnectionAngle { get; set; }
    }
}
