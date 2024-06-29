namespace CIM
{
    public abstract class IdentifiedObject
    {
        public string name { get; set; }
        public string aliasName { get; set; }
        public string description { get; set; }
        public Guid mRID { get; set; }
    }
}
