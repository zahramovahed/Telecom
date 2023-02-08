namespace Telecom.API.Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? CompanyName { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? ServiceAddress { get; set; }
        public virtual FamilierType? FamilierType { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual string? Telephone { get; set; }
    }
   public enum CustomerType
    {
        real=0,legal=1
    }
    public enum FamilierType
    {
        friends=0,tv=1,sms=2,billbords=3
    }
}
