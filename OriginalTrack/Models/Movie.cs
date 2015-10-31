using System;
using System.Collections.Generic;

namespace OriginalTrack.Models
{
    public class Movie
    {
        public Movie(Guid id, string name, List<Language> languages)
        {
            Id = id;
            Name = name;
            Languages = languages;
        }

        public Guid Id { get; private set; }
        
        public string Name { get; private set; }

        public Cinema Cinemas { get; private set; }

        public List<Language> Languages { get; private set; } 
    }
}