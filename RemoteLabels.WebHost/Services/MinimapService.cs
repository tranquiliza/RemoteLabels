using Microsoft.Extensions.Configuration;
using RemoteLabels.Api.Contract.Models;
using RemoteLabels.SignalR.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost.Services
{
    public class MinimapService
    {
        private SignalRClient signalRClient;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public MinimapService(IHttpClientFactory httpClientFactory, IApplicationConfiguration applicationConfiguration)
        {
            client = httpClientFactory.CreateClient();
            apiUrl = applicationConfiguration.ApiUrl;
        }

        public async Task<LatestPositionModel> GetLatestPosition()
        {
            var url = apiUrl + "/location/tranquiliza";
            var json = await client.GetStringAsync(url).ConfigureAwait(false);
            return JsonSerializer.Deserialize<LatestPositionModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task InitializeSignalRClient(Func<object, LocationUpdatedEventArgs, Task> callback)
        {
            signalRClient = new SignalRClient("tranquiliza", apiUrl);
            signalRClient.LocationUpdated += async (sender, e) => await callback(sender, e).ConfigureAwait(false);
            await signalRClient.StartAsync().ConfigureAwait(false);
        }
    }
}
