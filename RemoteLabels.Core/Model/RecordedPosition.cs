using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core.Model
{
    public class RecordedPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Username { get; set; }
    }
}
