using MovieExtended.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace MovieExtended
{
    public static class SessionFactoryConfig 
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var configuration = new Configuration();
            configuration.Configure();
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<CinemaMapping>();
            modelMapper.AddMapping<CompanyMapping>();
            configuration.AddDeserializedMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            var factory = configuration.BuildSessionFactory();

            new SchemaExport(configuration).Execute(false, true, false);

            return factory;
        }
    }
}