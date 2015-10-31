using System;

namespace OriginalTrack.Models
{
    public class Cinema
    {
        public Cinema(Guid id, string name, string address, Company owner)
        {
            Id = id;
            Name = name;
            Address = address;
            Owner = owner;;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }

        public string Address { get; private set; }

        public Company Owner { get; private set; }
    }
}