using RemoteLabels.Core;
using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.Sql
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ISqlAccess sql;

        public PositionRepository(IConnectionStringProvider connectionStringProvider)
        {
            sql = SqlAccessBase.Create(connectionStringProvider.ConnectionString);
        }

        public async Task InsertPosition(RecordedPosition recordedPosition)
        {
            try
            {
                using (var command = sql.CreateStoredProcedure("[Core].[InsertPosition]"))
                {
                    command.WithParameter("latitude", recordedPosition.Latitude)
                    .WithParameter("longitude", recordedPosition.Longitude)
                    .WithParameter("altitude", recordedPosition.Altitude)
                    .WithParameter("timeStamp", recordedPosition.TimeStamp)
                    .WithParameter("username", recordedPosition.Username);

                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                // LOG
                throw;
            }
        }

        public async Task<RecordedPosition> GetLatestPositionForUser(string username)
        {
            try
            {
                using (var command = sql.CreateStoredProcedure("[Core].[GetLatestPositionForUser]"))
                {
                    command.WithParameter("username", username);

                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow).ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            return new RecordedPosition
                            {
                                Latitude = reader.GetDouble("latitude"),
                                Longitude = reader.GetDouble("longitude"),
                                Altitude = reader.GetDouble("altitude"),
                                TimeStamp = reader.GetDateTime("timestamp"),
                                Username = reader.GetString("username")
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception)
            {
                // LOG
                throw;
            }
        }
    }
}
