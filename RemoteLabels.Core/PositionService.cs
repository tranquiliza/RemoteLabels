using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Core
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository positionRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public PositionService(IPositionRepository positionRepository, IDateTimeProvider dateTimeProvider)
        {
            this.positionRepository = positionRepository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task SavePosition(double lat, double lon, double? alt, string username)
        {
            var recordedPosition = new RecordedPosition
            {
                Latitude = lat,
                Longitude = lon,
                Altitude = alt ?? 0,
                TimeStamp = dateTimeProvider.UtcNow,
                Username = username
            };

            await positionRepository.InsertPosition(recordedPosition).ConfigureAwait(false);
        }

        public async Task<RecordedPosition> GetLatestPositionForUser(string username)
        {
            return await positionRepository.GetLatestPositionForUser(username).ConfigureAwait(false);
        }
    }
}
