namespace CIM
{
    /// <summary>
    /// Transformer resistance based on the star model.
    /// </summary>
    /// <remarks>
    /// Used for 2- and 3-winding transformers.
    /// </remarks>
    public class TransformerStarImpedance : IdentifiedObject
    {
        public double r { get; set; }
        public double x { get; set; }
        public TransformerEnd[] TransformerEnd { get; set; }
        public TransformerEndInfo TransformerEndInfo { get; set; }
    }
}
