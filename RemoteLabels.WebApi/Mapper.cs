using RemoteLabels.Api.Contract.Models;
using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebApi
{
    public static class Mapper
    {
        public static LatestPositionModel Map(this RecordedPosition latest)
        {
            return new LatestPositionModel
            {
                Altitude = latest.Altitude,
                Latitude = latest.Latitude,
                Longitude = latest.Longitude,
                TimeStamp = latest.TimeStamp
            };
        }
    }
}
