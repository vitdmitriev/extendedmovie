using System;

namespace OriginalTrack.Models
{
    public class Language
    {
        public Language(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }
    }
}