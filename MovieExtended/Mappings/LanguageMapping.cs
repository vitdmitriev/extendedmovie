using MovieExtended.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MovieExtended.Mappings
{
    public class LanguageMapping : ClassMapping<Language>
    {
        public LanguageMapping()
        {
            Id(model => model.Id, mapper =>
            {
                mapper.Column("Id");
                mapper.Generator(Generators.Guid);
            });
            Property(model => model.Name, mapper => mapper.Column("Name"));
            ManyToOne(model => model.Movie, mapper =>
            {
                mapper.Cascade(Cascade.All);
                mapper.Column("MovieId");
            });
            ManyToOne(model => model.TrackFile, mapper =>
            {
                mapper.Cascade(Cascade.None);
                mapper.Column("FileId");
            });
        }
    }
}