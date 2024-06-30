namespace CIM
{
    public abstract class IdentifiedObject
    {
        public string name { get; set; } = string.Empty;
        public string aliasName { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public Guid mRID { get; set; }
    }
}
