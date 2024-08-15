namespace CIM
{
    /// <summary>
    /// Parameters of the short-circuit test of the transformer winding.
    /// </summary>
    public class ShortCircuitTest : TransformerTest
    {
        public double loss { get; set; }
        public double voltage { get; set; }
        public int energizedEndStep { get; set; }
        public int groundedEndStep { get; set; }
        public TransformerEndInfo EnergisedEnd { get; set; }
        public TransformerEndInfo[] GroundedEnds { get; set; }
    }
}
