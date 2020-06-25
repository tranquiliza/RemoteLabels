using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public class BitrateService : IBitrateService
    {
        private readonly IBitrateRepository bitrateRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public BitrateService(IBitrateRepository bitrateRepository, IDateTimeProvider dateTimeProvider)
        {
            this.bitrateRepository = bitrateRepository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task SaveBitrate(string username, int bitrate)
        {
            var model = new RecordedBitrate { Bitrate = bitrate, Username = username, Timestamp = dateTimeProvider.UtcNow };
            await bitrateRepository.SaveBitrate(model).ConfigureAwait(false);
        }
    }
}
