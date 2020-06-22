using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string ApiUrl { get; } = "https://tranquiliza.dynu.net/streamlabelapi";
        //public string ApiUrl { get; } = "https://localhost:44318";
    }
}
