using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost.Services
{
    public class LocationSpyService
    {
        private readonly CancellationTokenSource cts;

        public LocationSpyService()
        {
            cts = new CancellationTokenSource();
        }

        private readonly TimeSpan interval = TimeSpan.FromSeconds(10);

        public async Task Run(Func<Task> callback)
        {
            while (!cts.IsCancellationRequested)
            {
                await callback().ConfigureAwait(false);
                await Task.Delay(interval).ConfigureAwait(false);
            }
        }

        public void Stop()
        {
            cts.Cancel();
        }
    }
}
