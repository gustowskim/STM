using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;

namespace STM.DomainLayer
{
    public class NHibernateSessionFactory
    {
        public static ISessionFactory Create()
        {
            return Create(CreateConfiguration());
        }

        public static ISessionFactory Create(Configuration configuration)
        {
            var sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }
        
        public static Configuration CreateConfiguration()
        {
            var connectionString = "";

            var properties = CreatePropertiesForSqlServer(connectionString);

            var mapping = new ModelMapper();
            //TODO: Change typeof to any valid Mapping from Mappings folder!
            mapping.AddMappings(typeof(NHibernateSessionFactory).Assembly.GetTypes());
            
            var configuration = new Configuration { Properties = properties };
            configuration.AddMapping(mapping.CompileMappingForAllExplicitlyAddedEntities());

            return configuration;
        }

        protected static Dictionary<string, string> CreatePropertiesForSqlServer(string connectionString)
        {
            var properties = new Dictionary<string, string>
                {
                    { "connection.driver_class", "NHibernate.Driver.SqlClientDriver" },
                    { "dialect", "NHibernate.Dialect.MsSql2012Dialect" },
                    { "connection.provider", "NHibernate.Connection.DriverConnectionProvider, NHibernate" },
                    { "connection.connection_string", connectionString },
                    { "show_sql", "true" },
                    //{ NHibernate.Cfg.Environment.SqlExceptionConverter, typeof(MHibernateExceptionConverter).AssemblyQualifiedName}
                };

            return properties;
        }
    }
}
