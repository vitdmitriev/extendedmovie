﻿using MovieExtended.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MovieExtended.Mappings
{
    public class MovieMapping : ClassMapping<Movie>
    {
        public MovieMapping()
        {
            Id(model => model.Id, mapper =>
            {
                mapper.Column("Id");
                mapper.Generator(Generators.Guid);
            });
            Property(model => model.Name, mapper => mapper.Column("Name"));
            Property(model => model.CinemaId, mapper => mapper.Column("CinemaId"));
        }
    }
}