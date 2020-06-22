using Microsoft.AspNetCore.Mvc;
using RemoteLabels.Api.Contract.Models;
using RemoteLabels.Core;
using RemoteLabels.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly ILabelRepository labelRepository;

        public LabelController(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLabel([FromBody]LabelUpdateModel labelUpdateModel)
        {
            labelRepository.UpdateLabel(labelUpdateModel.Text);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLabel()
        {
            var result = labelRepository.GetCurrentLabel();
            return Ok(result);
        }
    }
}
