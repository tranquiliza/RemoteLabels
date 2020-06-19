using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IPositionService
    {
        Task SavePosition(decimal lat, decimal lon, string username);
    }
}
