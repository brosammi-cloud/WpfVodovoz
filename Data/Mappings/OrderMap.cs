using FluentNHibernate.Mapping;
using System.Windows.Documents;
using WpfVodovoz.Models;


namespace WpfVodovoz.Data.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orders");

            Id(x => x.OrderId).GeneratedBy.Identity();

            Map(x => x.OrderNum);
            Map(x => x.OrderDate);
            Map(x => x.Amount);

            References(x => x.Employee).Column("EmployeeId");   
            References(x => x.Contractor).Column("ContractorId");
        }
    }
}
