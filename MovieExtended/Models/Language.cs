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

        public Guid Id { get; protected set; } 

        public string Name { get; protected set; }

        public File TrackFile { get; protected set; }
    }
}