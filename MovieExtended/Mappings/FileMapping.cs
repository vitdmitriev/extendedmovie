using MovieExtended.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MovieExtended.Mappings
{
    public class FileMapping : ClassMapping<File>
    {
        public FileMapping()
        {
            Id(model => model.Id, mapper =>
            {
                mapper.Generator(Generators.Guid);
                mapper.Column("Id");
            });
            Property(model => model.FilePath, mapper => mapper.Column("FilePath"));
            Property(model => model.FileType, mapper => mapper.Column("FileType"));
        }
    }
}