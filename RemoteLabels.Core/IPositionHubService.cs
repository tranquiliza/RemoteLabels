using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core
{
    public interface IPositionHubService
    {
        void AddUser(string connectionId, string username);
        void RemoveUser(string connectionId);
        string[] GetConnectionIdsRelatedTo(string username);
    }
}
