namespace CIM
{
    /// <summary>
    /// Component of a full polygon type transformer equivalent circuit.
    /// </summary>
    public class TransformerMeshImpedance : IdentifiedObject
    {
        public double r { get; set; }
        public double x { get; set; }
        public TransformerEnd FromTransformerEnd { get; set; }
        public TransformerEnd[] ToTransformerEnd { get; set; }
    }
}
