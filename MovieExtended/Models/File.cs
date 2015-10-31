using System;

namespace MovieExtended.Models
{
    public class File
    {
        public File(Guid id, Uri filePath, FileType fileType)
        {
            Id = id;
            FilePath = filePath;
            FileType = fileType;
        }

        public Guid Id { get; protected set; } 

        public Uri FilePath { get; protected set; }

        public FileType FileType { get; protected set; }
    }

    public enum FileType
    {
        Track,
        Subtitles
    }
}