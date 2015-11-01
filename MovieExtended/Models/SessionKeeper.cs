﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping;
using NHibernate.Util;

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
        private readonly Dictionary<Guid, DateTime> _timeMarks = new Dictionary<Guid, DateTime>(); 
        
        public void SetState(Guid movieId, SessionState state, DateTime changingOccured)
        {
            if (state == SessionState.Closed)
            {
                _sessions.RemoveAll(session => session.MovieId == movieId);
            }
            if (state == SessionState.Active)
            {
                _timeMarks.Add(movieId, changingOccured);
                foreach (var session in _sessions.Where(s => s.MovieId == movieId))
                {
                    session.SessionState = state;
                }
            }
        }

        public DateTime GetMovieStartTime(Guid sessionId)
        {
            var movieId = GetMovieId(sessionId);
            return _timeMarks[movieId];
        }
    }
}