using System;

namespace MovieExtended.Models
{
    public class Cinema
    {
        public Cinema(Guid id, string name, string address, Company company)
        {
            Id = id;
            Name = name;
            Address = address;
            Company = company;
        }

        protected Cinema()
        {
            
        }

        public virtual Guid Id { get; protected set; } 
        
        public virtual string Name { get; protected set; }

        public virtual string Address { get; protected set; }

        public virtual Company Company { get; protected set; }
    }
}