using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IPositionService
    {
        Task SavePosition(double lat, double lon, double? alt, string username);
        Task<RecordedPosition> GetLatestPositionForUser(string username);
    }
}
