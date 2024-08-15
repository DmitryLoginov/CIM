namespace CIM
{
    /// <summary>
    /// Technical parameters of the transformer output.
    /// </summary>
    public class TransformerEndInfo : AssetInfo
    {
        public double ratedU { get; set; }
        public int endNumber { get; set; }
        public NoLoadTest[] EnergisedEndNoLoadTests { get; set; }
        public PowerTransformerEnd[] PowerTransformerEnd { get; set; }
        public ShortCircuitTest[] EnergisedEndShortCircuitTests { get; set; }
        public ShortCircuitTest[] GroundedEndShortCircuitTests { get; set; }
        public TransformerStarImpedance TransformerStarImpedance { get; set; }
    }
}
