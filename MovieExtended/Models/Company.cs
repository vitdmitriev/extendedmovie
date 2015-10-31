﻿using System;

namespace MovieExtended.Models
{
    public class Company
    {
        public Company(Guid? id, string name, Uri website, Uri photoUri)
        {
            Id = id;
            Name = name;
            Website = website;
            PhotoUri = photoUri;
        }

        protected Company()
        {
            
        }

        public virtual Guid? Id { get; protected set; } 

        public virtual string Name { get; protected set; }

        public virtual Uri Website { get; protected set; }

        public virtual Uri PhotoUri { get; protected set; }
    }
}