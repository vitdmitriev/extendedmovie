﻿using MovieExtended.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MovieExtended.Mappings
{
    public class CinemaMapping : ClassMapping<Cinema>
    {
        public CinemaMapping()
        {
            Id(model => model.Id, mapper =>
            {
                mapper.Column("Id");
                mapper.Generator(Generators.Guid);
            });
            Property(model => model.Name, mapper => mapper.Column("Name"));
            Property(model => model.Address, mapper => mapper.Column("Address"));
            ManyToOne(model => model.Company, mapper =>
            {
                mapper.Column("CompanyId");
                mapper.Class(typeof(Company));
            });
        }
    }
}