using Microsoft.AspNetCore.Mvc;
using RemoteLabels.Api.Contract.Models;
using RemoteLabels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitrateController : ControllerBase
    {
        private readonly IBitrateService bitrateService;

        public BitrateController(IBitrateService bitrateService)
        {
            this.bitrateService = bitrateService;
        }

        [HttpPost("{username}")]
        public async Task <IActionResult> LogBitrate([FromRoute]string username, [FromBody]LogBitrateModel model)
        {
            await bitrateService.SaveBitrate(username, model.Bitrate).ConfigureAwait(false);

            return Ok();
        }
    }
}
