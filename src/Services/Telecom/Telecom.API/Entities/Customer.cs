namespace Telecom.API.Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? LastName { get; set; }
        //public string? CompanyName { get; set; }
        //public string? Address { get; set; }
        //public string? ServiceAddress { get; set; }
        //public int? FamilierType { get; set; }
        //public Int16 CustomerType { get; set; }
    }
}
