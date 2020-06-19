using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core.Model
{
    public class RecordedPosition
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Username { get; set; }
    }
}
