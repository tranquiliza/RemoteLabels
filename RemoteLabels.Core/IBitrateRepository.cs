using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IBitrateRepository
    {
        Task SaveBitrate(RecordedBitrate bitrate);
    }
}
