using System;

namespace MovieExtended.Models
{
    public class Session
    {
        public Session(Guid sessionId, Guid movieId)
        {
            SessionId = sessionId;
            MovieId = movieId;
        }

        public Guid SessionId { get; private set; }
        public Guid MovieId { get; private set; }
        public SessionState SessionState { get; set; }
    }
}