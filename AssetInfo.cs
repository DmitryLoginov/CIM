namespace CIM
{
    /// <summary>
    /// Base class for describing technical parameters of various types of equipment.
    /// </summary>
    public abstract class AssetInfo : IdentifiedObject
    {
        public PowerSystemResource PowerSystemResources { get; set; }
    }
}
