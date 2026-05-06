using FluentNHibernate.Mapping;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data.Mappings
{
    public class ContractorMap : ClassMap<Contractor>
    {
        public ContractorMap()
        {
            Table("contractors");

            Id(x => x.СontractorId).GeneratedBy.Identity();

            Map(x => x.Name).Not.Nullable();
            Map(x => x.INN);
            //Map(x => x.EmployeeId);
            References(x => x.Responsible).Column("EmployeeId");
        }
    }
}