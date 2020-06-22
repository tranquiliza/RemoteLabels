using Microsoft.AspNetCore.SignalR;
using RemoteLabels.Core;
using RemoteLabels.SignalR.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi.Hubs
{
    public class PositionHub : Hub
    {
        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();

        public Task Register(string username)
        {
            var currentId = Context.ConnectionId;
            if (!userLookup.ContainsKey(currentId))
            {
                userLookup.Add(currentId, username);
            }

            return Task.CompletedTask;
        }

        public async Task UpdateLocation(string username, double latitude, double longitude, double? altitude)
        {
            await Clients.All.SendAsync(Methods.UPDATELOCATION, username, latitude, longitude, altitude);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            // try to get connection
            string id = Context.ConnectionId;

            userLookup.Remove(id);

            await base.OnDisconnectedAsync(e);
        }
    }
}
