using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.SignalR.Contract
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        public LocationUpdatedEventArgs(string username, double latitude, double longitude, double? altitude)
        {
            Username = username;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public string Username { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public double? Altitude { get; }
    }
}
