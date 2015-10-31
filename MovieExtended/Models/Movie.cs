using System;

namespace MovieExtended.Models
{
    public class Movie
    {
        public Movie(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Movie()
        {
        }

        public virtual Guid Id { get; protected set; }
        
        public virtual string Name { get; protected set; }
        
        public virtual Cinema Cinema { get; protected set; }
    }
}