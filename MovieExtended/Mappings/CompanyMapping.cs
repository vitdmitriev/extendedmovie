using MovieExtended.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MovieExtended.Mappings
{
    public class CompanyMapping : ClassMapping<Company>
    {
        public CompanyMapping()
        {
            Id(model => model.Id, mapper =>
            {
                mapper.Column("Id");
                mapper.Generator(Generators.Guid);
            });
            Property(model => model.Name, mapper => mapper.Column("Name"));
            Property(model => model.PhotoUri, mapper => mapper.Column("PhotoUri"));
            Property(model => model.Website, mapper => mapper.Column("Website"));
        }
    }
}