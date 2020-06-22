using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RemoteLabels.Api.Contract.Models;
using RemoteLabels.Core;
using RemoteLabels.SignalR.Contract;
using RemoteLabels.WebApi.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi.Controlles
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IPositionService positionService;
        private readonly IHubContext<PositionHub> positionHub;

        public LocationController(IPositionService positionService, IHubContext<PositionHub> positionHub)
        {
            this.positionService = positionService;
            this.positionHub = positionHub;
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> UpdateLocation([FromRoute]string username, [FromBody]LocationUpdateModel locationUpdateModel)
        {
            await positionService.SavePosition(locationUpdateModel.Latitude, locationUpdateModel.Longitude, locationUpdateModel.Altitude, username).ConfigureAwait(false);

            await positionHub.Clients.All.SendAsync(Methods.UPDATELOCATION, username, locationUpdateModel.Latitude, locationUpdateModel.Longitude, locationUpdateModel.Altitude).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetLatestLocation([FromRoute]string username)
        {
            var result = await positionService.GetLatestPositionForUser(username).ConfigureAwait(false);

            return Ok(result.Map());
        }
    }
}
