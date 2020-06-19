using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString { get; }

        public ConnectionStringProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
