using System;

namespace OriginalTrack.Models
{
    public class File
    {
        public File(Guid id, Uri filePath, FileType fileType)
        {
            Id = id;
            FilePath = filePath;
            FileType = fileType;
        }

        public Guid Id { get; private set; } 

        public Uri FilePath { get; private set; }

        public FileType FileType { get; private set; }
    }

    public enum FileType
    {
        Track,
        Subtitles
    }
}