using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
