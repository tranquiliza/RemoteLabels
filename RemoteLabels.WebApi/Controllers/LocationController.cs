using Microsoft.AspNetCore.Mvc;
using RemoteLabels.Core;
using RemoteLabels.WebApi.Models;
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

        public LocationController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> UpdateLocation([FromRoute]string username, [FromBody]LocationUpdateModel locationUpdateModel)
        {
            await positionService.SavePosition(locationUpdateModel.Latitude, locationUpdateModel.Longitude, locationUpdateModel.Altitude, username).ConfigureAwait(false);

            return Ok();
        }
    }
}
