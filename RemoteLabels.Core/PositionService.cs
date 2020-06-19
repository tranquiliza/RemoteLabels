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

        public async Task SavePosition(decimal lat, decimal lon, string username)
        {
            var recordedPosition = new RecordedPosition
            {
                Latitude = lat,
                Longitude = lon,
                TimeStamp = dateTimeProvider.UtcNow,
                Username = username
            };

            await positionRepository.InsertPosition(recordedPosition).ConfigureAwait(false);
        }
    }
}
