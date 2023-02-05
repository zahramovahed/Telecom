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
            Id(i => i.Id, map => map.Generator(Generators.Guid));
            Property(x => x.Name);
            Property(x => x.LastName);

        }
    }
}
