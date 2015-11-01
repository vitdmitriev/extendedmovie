using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping;

namespace MovieExtended.Models
{
    public class SessionKeeper
    {
        public Guid CreateSession(Guid movieId)
        {
            var session = new Session(Guid.NewGuid(), movieId);
            _sessions.Add(session);
            return session.SessionId;
        }

        public bool CheckIfSessionExists(Guid sessionId)
        {
            return _sessions.Any(session => session.SessionId == sessionId);
        }

        public SessionState GetSessionState(Guid sessionId)
        {
            var session = _sessions.FirstOrDefault(innerSession => innerSession.SessionId == sessionId);
            return session == null ? SessionState.Closed : session.SessionState;
        }

        public Guid GetMovieId(Guid sessionId)
        {
            var session = _sessions.FirstOrDefault(innerSession => innerSession.SessionId == sessionId);
            return session == null ? Guid.Empty : session.MovieId;
        }

        private readonly List<Session> _sessions = new List<Session>();
    }
}