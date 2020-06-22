using Microsoft.Extensions.Hosting.Internal;
using RemoteLabels.Api.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost.Services
{
    public class LabelService
    {
        private readonly HttpClient client;
        private readonly string apiUrl;

        public LabelService(IHttpClientFactory httpClientFactory, IApplicationConfiguration applicationConfiguration)
        {
            client = httpClientFactory.CreateClient();
            apiUrl = applicationConfiguration.ApiUrl + "/label";
        }

        public Task<string> GetCurrentLabel()
            => client.GetStringAsync(apiUrl);

        public async Task UpdateLabel(LabelUpdateModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync(apiUrl, content).ConfigureAwait(false);
        }
    }
}
