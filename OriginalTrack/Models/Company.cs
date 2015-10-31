using System;

namespace OriginalTrack.Models
{
    public class Company
    {
        public Company(Guid id, string name, Uri website, Cinema[] cinemas)
        {
            Id = id;
            Name = name;
            Website = website;
            Cinemas = cinemas;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }

        public Uri Website { get; private set; }

        public Cinema[] Cinemas { get; private set; }
    }
}