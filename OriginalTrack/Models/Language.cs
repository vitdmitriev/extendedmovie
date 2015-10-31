using System;

namespace OriginalTrack.Models
{
    public class Language
    {
        public Language(Guid id, string name, File trackFile)
        {
            Id = id;
            Name = name;
            TrackFile = trackFile;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }

        public File TrackFile { get; private set; }
    }
}