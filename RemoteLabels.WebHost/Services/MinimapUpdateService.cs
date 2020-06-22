using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost.Services
{
    public class MinimapUpdateService
    {
        public RecordedPosition LatestRecordedPosition = null;

        private readonly IPositionService positionService;
        private readonly CancellationTokenSource cts;

        public MinimapUpdateService(IPositionService positionService)
        {
            this.positionService = positionService;
            cts = new CancellationTokenSource();
        }

        public async Task UpdatePosition(string username)
        {
            LatestRecordedPosition = await positionService.GetLatestPositionForUser(username).ConfigureAwait(false);
        }

        public void Stop()
        {
            cts.Cancel();
        }
    }
}
