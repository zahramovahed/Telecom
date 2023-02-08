using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Telecom.API.Entities
{
    public class ContractMap : ClassMapping<Contract>
    {
        public ContractMap()
        {
            Schema("dbo");
            Table("Contract");
            Id(i => i.Id, map => map.Generator(Generators.Native));
            ManyToOne(x => x.Customer, map => { map.Column("CustomerId");map.NotNullable(true); });
            Property(i => i.ServiceType);
            Property(i => i.ContractType);
        }
    }
}
