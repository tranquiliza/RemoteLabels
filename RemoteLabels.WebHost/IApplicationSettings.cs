using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost
{
    public interface IApplicationSettings
    {
        public string FilePath { get; }
    }
}
