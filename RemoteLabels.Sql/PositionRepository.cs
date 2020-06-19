using RemoteLabels.Core;
using RemoteLabels.Core.Model;
using System;
using System.Collections.Generic;
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
                using var command = sql.CreateStoredProcedure("[Core].[InsertPosition]")
                    .WithParameter("latitude", recordedPosition.Latitude)
                    .WithParameter("longitude", recordedPosition.Longitude)
                    .WithParameter("timeStamp", recordedPosition.TimeStamp)
                    .WithParameter("username", recordedPosition.Username);

                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                // LOG
                throw;
            }
        }

        public async Task<RecordedPosition> GetLatestPositionForUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
