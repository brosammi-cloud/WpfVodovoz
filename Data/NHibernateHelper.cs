using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(
                    FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
                        .ConnectionString(connectionString)
                        .ShowSql()
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Employee>())
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Contractor>())
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(false, true);
                    /*var schemaExport = new SchemaExport(cfg);
                    schemaExport.Drop(false, true);
                    schemaExport.Create(false, true);*/
                })
                .BuildSessionFactory();
        }
    }
}
