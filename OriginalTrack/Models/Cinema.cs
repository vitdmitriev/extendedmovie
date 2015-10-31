using System;

namespace OriginalTrack.Models
{
    public class Cinema
    {
        public Cinema(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }

        public string Address { get; private set; }
    }
}