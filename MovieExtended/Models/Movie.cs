using System;
using System.Collections.Generic;

namespace MovieExtended.Models
{
    public class Movie
    {
        public Movie(Guid id, string name, List<Language> languages)
        {
            Id = id;
            Name = name;
            Languages = languages;
        }
        
        public Guid Id { get; protected set; }
        
        public string Name { get; protected set; }
        
        public Cinema Cinemas { get; protected set; }

        public List<Language> Languages { get; protected set; } 
    }
}