using RemoteLabels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string FilePath => "labels";
    }
}
