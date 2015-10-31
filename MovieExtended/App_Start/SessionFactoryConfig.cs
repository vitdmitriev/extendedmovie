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
            modelMapper.AddMapping<MovieMapping>();
            modelMapper.AddMapping<LanguageMapping>();
            modelMapper.AddMapping<FileMapping>();
            configuration.AddDeserializedMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            var factory = configuration.BuildSessionFactory();

            new SchemaUpdate(configuration).Execute(false, true);

            return factory;
        }
    }
}