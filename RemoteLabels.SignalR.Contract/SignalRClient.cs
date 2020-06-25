using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.SignalR.Contract
{
    public class SignalRClient : IAsyncDisposable
    {
        public const string HUBURL = "/PositionHub";

        private readonly string _hubUrl;
        private HubConnection _hubConnection;

        /// <summary>
        /// Ctor: create a new client for the given hub URL
        /// </summary>
        /// <param name="siteUrl">The base URL for the site, e.g. https://localhost:1234 </param>
        /// <remarks>
        /// Changed client to accept just the base server URL so any client can use it, including ConsoleApp!
        /// </remarks>
        public SignalRClient(string username, string siteUrl)
        {
            // check inputs
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrWhiteSpace(siteUrl))
                throw new ArgumentNullException(nameof(siteUrl));
            // save username
            _username = username;
            // set the hub URL
            _hubUrl = siteUrl.TrimEnd('/') + HUBURL;
        }

        private readonly string _username;

        private bool _started = false;

        public async Task StartAsync()
        {
            if (!_started)
            {
                // create the connection using the .NET SignalR client
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_hubUrl)
                    .Build();

                // add handler for receiving messages
                _hubConnection.On<string, double, double, double?>(Methods.UPDATELOCATION, HandleUpdateLocation);

                // start the connection
                await _hubConnection.StartAsync();

                _started = true;

                // register user on hub to let other clients know they've joined
                await _hubConnection.SendAsync(Methods.REGISTER, _username);
            }
        }

        private void HandleUpdateLocation(string username, double latitude, double longitude, double? altitude)
        {
            LocationUpdated?.Invoke(this, new LocationUpdatedEventArgs(username, latitude, longitude, altitude));
        }

        public event LocationUpdatedEventHandler LocationUpdated;

        public async Task StopAsync()
        {
            if (_started)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
                _started = false;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await StopAsync();
        }
    }

    /// <summary>
    /// Delegate for the message handler
    /// </summary>
    /// <param name="sender">the SignalRclient instance</param>
    /// <param name="e">Event args</param>
    public delegate void LocationUpdatedEventHandler(object sender, LocationUpdatedEventArgs e);
}
