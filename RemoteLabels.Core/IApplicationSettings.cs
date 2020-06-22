using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public interface IApplicationSettings
    {
        string FilePath { get; }
    }
}
