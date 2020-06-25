using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RemoteLabels.Core
{
    public class PositionHubService : IPositionHubService
    {
        private class ConnectionRelation
        {
            public string Username { get; private set; }
            public string ConnectionId { get; private set; }

            public ConnectionRelation(string connectionId, string username)
            {
                ConnectionId = connectionId;
                Username = username;
            }
        }

        private static readonly List<ConnectionRelation> userLookup = new List<ConnectionRelation>();

        public void AddUser(string connectionId, string username)
        {
            if (!userLookup.Any(x => x.ConnectionId == connectionId))
                userLookup.Add(new ConnectionRelation(connectionId, username));
        }

        public string[] GetConnectionIdsRelatedTo(string username)
            => userLookup.Where(x => x.Username == username).Select(x => x.ConnectionId).ToArray();

        public void RemoveUser(string connectionId)
        {
            var relationToRemove = userLookup.Find(x => x.ConnectionId == connectionId);
            if (relationToRemove != null)
                userLookup.Remove(relationToRemove);
        }
    }
}
