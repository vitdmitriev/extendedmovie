using System;

namespace MovieExtended.Models
{
    public class Language
    {
        public Language(Guid id, string name, File trackFile)
        {
            Id = id;
            Name = name;
            TrackFile = trackFile;
        }
        protected Language() { }

        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual Movie Movie { get; set; }

        public virtual File TrackFile { get; protected set; }
    }
}