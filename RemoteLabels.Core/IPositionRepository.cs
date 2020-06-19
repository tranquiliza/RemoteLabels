using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IPositionRepository
    {
        Task InsertPosition(RecordedPosition recordedPosition);
        Task<RecordedPosition> GetLatestPositionForUser(string username);
    }
}
