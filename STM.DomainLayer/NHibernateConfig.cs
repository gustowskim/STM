using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace STM.DomainLayer
{
    public class NHibernateConfig
    {
        public static ISessionFactory SessionFactory { get; set; }
        public static Configuration Configuration { get; set; }

        public static void Configure()
        {
            Configuration = CreateConfiguration();
            SessionFactory = Configuration.BuildSessionFactory();
        }

        private static Configuration CreateConfiguration()
        {
            var config = new Configuration();

            config.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<Sql2008ClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;

                db.Timeout = 10;
            });

            var mappings = CreateMappings();
            config.AddDeserializedMapping(mappings, null);
            SchemaMetadataUpdater.QuoteTableAndColumns(config);

            return config;
        }

        private static HbmMapping CreateMappings()
        {
            var mapper = new ModelMapper();

            //TODO: Change typeof to any valid Mapping from Mappings folder!
            mapper.AddMappings(Assembly.GetAssembly(typeof(NHibernateConfig)).GetExportedTypes());
            var mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mappings;
        }
    }
}
