namespace Telecom.API.Entities
{
    public class Contract
    {
       public virtual Customer? Customer { get; set; }
        public virtual int Id { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ContractType ContractType { get; set; }


    }
    public enum ServiceType
    {
        ADSl2M=0,ADSL3M=1,ADSL4M=2,ADSL8M=3,ADSL16M=4
    }
    public enum ContractType
    {
        Month3=0,Month6=1,Year1=2
    }
}
