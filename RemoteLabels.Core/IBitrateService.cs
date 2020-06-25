using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IBitrateService
    {
        Task SaveBitrate(string username, int bitrate);
    }
}
