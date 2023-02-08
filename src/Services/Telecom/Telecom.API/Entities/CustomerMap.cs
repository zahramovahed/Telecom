using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Telecom.API.Entities
{
    public class CustomerMap:ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Schema("[dbo]");
            Table("[Customer]");
            Id(i => i.Id, map => map.Generator(Generators.Native));
            Property(x => x.Name);
            Property(x => x.LastName);
            Property(x => x.CompanyName);
            Property(x => x.Address);
            Property(x => x.ServiceAddress);
            Property(x => x.FamilierType);
            Property(x => x.CustomerType);
            Property(x => x.Telephone);

            
    }
    }
}
