using FluentNHibernate.Mapping;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("employees");

            Id(x => x.EmployeeId).GeneratedBy.Identity();

            Map(x => x.FullName).Not.Nullable();
            Map(x => x.Position).CustomType<int>();
            Map(x => x.BirthDate);
        }
    }
}