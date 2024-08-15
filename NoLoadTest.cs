namespace CIM
{
    /// <summary>
    /// Parameters of the no-load test of the transformer winding.
    /// </summary>
    public class NoLoadTest : TransformerTest
    {
        /// <summary>
        /// Idle losses, kW.
        /// </summary>
        public double loss { get; set; }
        /// <summary>
        /// Idle current, %.
        /// </summary>
        public double excitingCurrent { get; set; }
        /// <summary>
        /// Primary winding voltage, kV.
        /// </summary>
        public double energisedEndVoltage { get; set; }
        public TransformerEndInfo EnergisedEnd { get; set; }
    }
}
