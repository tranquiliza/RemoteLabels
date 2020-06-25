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
        private readonly IPositionHubService positionHubService;

        public PositionHub(IPositionHubService positionHubService)
        {
            this.positionHubService = positionHubService;
        }

        public Task Register(string username)
        {
            var currentId = Context.ConnectionId;
            positionHubService.AddUser(currentId, username);

            return Task.CompletedTask;
        }

        public async Task UpdateLocation(string username, double latitude, double longitude, double? altitude)
        {
            await Clients.All.SendAsync(Methods.UPDATELOCATION, username, latitude, longitude, altitude);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            string id = Context.ConnectionId;

            positionHubService.RemoveUser(id);

            await base.OnDisconnectedAsync(e);
        }
    }
}
